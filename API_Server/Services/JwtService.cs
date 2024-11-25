using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API_Server.Models;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
       
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly IMongoCollection<TokenData> _tokenData;
        private readonly UserService _userService;

        public JwtService(IConfiguration configuration, MongoDbService db, UserService userService)
        {
            _configuration = configuration;
            _tokenData = db.Tokens;
            _userService = userService;
            _secret = _configuration["JwtSettings:Secret"] ?? throw new ArgumentNullException(nameof(_secret));
            _issuer = _configuration["JwtSettings:Issuer"] ?? throw new ArgumentNullException(nameof(_issuer));
            _audience = _configuration["JwtSettings:Audience"] ?? throw new ArgumentNullException(nameof(_audience));
        }

        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var jti = Guid.NewGuid().ToString();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim("userName", user.Username),
                new Claim("userId", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }
        public async Task<TokenData> GetRefreshToken(string token)
        {
            var refreshToken = await _tokenData.Find(rt => rt.RefreshToken == token).FirstOrDefaultAsync();
            return refreshToken;

        }
        public async Task<bool> ValidateRefreshToken(string token, string userName)
        {
            var tokenData = await GetRefreshToken(token);

            if(tokenData == null || tokenData.Username != userName)
            {
                return false;
            }
            if (tokenData.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return false;
            }
            if(tokenData.RefreshTokensUsed.Contains(token))
            {
                return false ;
            }    
       
            return true;
        }
        public async Task SaveToken(TokenData token)
        {
            var existedToken = await _tokenData.Find(td => td.Username == token.Username).FirstOrDefaultAsync();

            if (existedToken != null)
            {
                existedToken.RefreshToken = token.RefreshToken;
                existedToken.RefreshTokensUsed = token.RefreshTokensUsed;
                existedToken.RefreshTokenExpiryTime = token.RefreshTokenExpiryTime;
                existedToken.Jti = token.Jti;

                await _tokenData.ReplaceOneAsync(td => td.Id == existedToken.Id, existedToken);
            }
            else
            {
                await _tokenData.InsertOneAsync(token);
            }
        }
        
        public async Task<string> NewGenerateAccessToken(string refreshToken, string userName)
        {
            var token = await GetRefreshToken(refreshToken);
            var isValidated = await ValidateRefreshToken(refreshToken, userName);
            if (!isValidated)
            {
                throw new UnauthorizedAccessException("Invalid token!");
            }

            token.RefreshTokensUsed.Add(refreshToken);

            var user = await _userService.GetUserByUserName(userName);
            var newAccessToken = GenerateAccessToken(user);

            var newRefreshToken = GenerateRefreshToken();
            token.RefreshToken = newRefreshToken;
            token.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await SaveToken(token);

            return newAccessToken;
        }
        public string GetJtiFromAccessToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var jti = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti)?.Value;
            return jti ?? string.Empty;
        }
    }
}

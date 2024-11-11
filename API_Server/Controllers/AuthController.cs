using Microsoft.AspNetCore.Mvc;
using API_Server.Services;
using API_Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using MongoDB.Driver;

namespace API_Server.Controllers
{
    [Route("api/refreshToken")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly MongoDbService _context;
        private readonly string _secret;

        public AuthController(JwtService jwtService, MongoDbService context, IConfiguration configuration)
        {
            _jwtService = jwtService;
            _context = context;
            _secret = configuration["JwtSettings:Secret"] ?? throw new ArgumentNullException(nameof(_secret));
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshToken request)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            try
            {
                // Validate the access token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };

                var principal = jwtTokenHandler.ValidateToken(request.accessToken, tokenValidationParameters, out SecurityToken validatedToken);

                if (validatedToken is not JwtSecurityToken jwtSecurityToken ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return BadRequest("Invalid token");
                }

                // Check if the access token has expired
                var expiryDateUnix = long.Parse(principal.Claims.First(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expiryDateTimeUtc = DateTimeOffset.FromUnixTimeSeconds(expiryDateUnix).UtcDateTime;

                if (expiryDateTimeUtc > DateTime.UtcNow)
                {
                    return BadRequest("This token hasn't expired yet");
                }

                // Check if the refresh token exists in the database
                var refreshToken = await _context.Tokens.Find(x => x.RefreshToken == request.refreshToken).FirstOrDefaultAsync();
                if (refreshToken == null)
                {
                    return BadRequest("Invalid refresh token");
                }

                // Check if the access token's JTI matches the refresh token's JTI
                var jtiClaim = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (jtiClaim == null || jtiClaim != refreshToken.Jti)
                {
                    return BadRequest("Invalid refresh token");
                }

                // Generate a new access token
                var user = await _context.Users.Find(x => x.Username == refreshToken.Username).FirstOrDefaultAsync();
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var newAccessToken = _jwtService.GenerateAccessToken(user);

                // Delete old access token from cookies
                Response.Cookies.Delete("accessToken");
                // Delete old refresh token from database
                await _context.Tokens.DeleteOneAsync(x => x.RefreshToken == request.refreshToken);
                // Add new access token to cookies
                Response.Cookies.Append("accessToken", newAccessToken);
                // Add new refresh token to database
                var newRefreshToken = _jwtService.GenerateRefreshToken();
                await _context.Tokens.InsertOneAsync(new TokenData
                {
                    RefreshToken = newRefreshToken,
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(5),
                    Username = user.Username,
                    Jti = Guid.NewGuid().ToString()
                });

                return Ok(new { accessToken = newAccessToken, 
                                refreshToken = newRefreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

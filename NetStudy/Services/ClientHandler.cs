using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class ClientHandler : DelegatingHandler
    {
        private readonly TokenService tokenService;
        public ClientHandler(TokenService tokenService, HttpMessageHandler innerHandler) : base(innerHandler)
        {
            this.tokenService = tokenService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            tokenService.AddAuthorizationHeader(request);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Refresh token when unauthorized
                var tokenRefreshed = await tokenService.HandleToken();

                if (tokenRefreshed)
                {
                    // Retry the original request with new access token
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenService.GetAccessToken());
                    return await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }
}

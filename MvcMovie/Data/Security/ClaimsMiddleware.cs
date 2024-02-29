using Microsoft.IdentityModel.Tokens;
using MvcMovie.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Data.Security
{
    public class ClaimsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ClaimsMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = "";

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                token = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault().ToString();
            //var token = _httpContextAccessor.HttpContext.Request.Cookies["authToken"];


            if (!string.IsNullOrEmpty(token))
            {
                token = token.Substring("Token: ".Length);
                token = token.Substring(0, token.Length - 1);

                var claims = GetClaimsFromToken(token);

                var claim = claims.FirstOrDefault(c => c.Type == "role");

                context.User.AddIdentity(new ClaimsIdentity(claims));
            }


            // Continuar a cadeia de middlewares
            await _next(context);
        }

        private IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var claims = securityToken.Claims;

            return claims;
        }
    }

}

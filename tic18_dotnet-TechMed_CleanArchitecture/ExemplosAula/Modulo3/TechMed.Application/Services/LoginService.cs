using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Auth;

namespace TechMed.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthService _authService;

        public LoginService(IAuthService authService)
        {
            _authService = authService;
        }

        public LoginViewModel? Authenticate(LoginInputModel login)
        {
            var passHashed = _authService.ComputeSha256Hash(login.Password);
            var defaultPass = _authService.ComputeSha256Hash("admin");

            if (login.Username != "admin" || passHashed != defaultPass)
                return null;

            var token = _authService.GenerateJwtToken(login.Username, "admin");

            return new LoginViewModel { Username = login.Username, Token = token };
        }
    }
}

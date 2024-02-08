using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel user)
        {
            var userViewModel = _loginService.Authenticate(user);

            if (userViewModel is null)
                return NoContent();

            return Ok(userViewModel);
        }
    }
}

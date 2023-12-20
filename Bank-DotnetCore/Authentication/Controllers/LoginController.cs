using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {

            _loginService = loginService;

        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginUserDto user)
        {
            var userResponse = await _loginService.Login(user);
            if (userResponse.Token == null)
            {
                return Unauthorized();
            }
            return Ok(userResponse);

        }
    }
}

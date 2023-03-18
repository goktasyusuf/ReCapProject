using Business.Abstract;
using Entities.Concrete.Dto_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = authService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var exists = authService.UserExists(userForRegisterDto.Email);

            if (!exists.Success)
            {
                return BadRequest(exists.Message);
            }
            var register = authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var check = authService.CreateAccessToken(register.Data);
            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            return Ok(check);
        }
    }
}

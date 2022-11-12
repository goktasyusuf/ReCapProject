using Business.Abstract;
using Entities.Concrete.DTO_s;
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
            // bi dk

            if(!userToLogin.success)
            {
                return BadRequest(userToLogin.message);
            }

            var result =authService.CreateAccessToken(userToLogin.data);

            if(result.success)
            {
                return Ok(result.data);
            }
            return BadRequest(result.message);

        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var exists = authService.UserExists(userForRegisterDto.Email);

            if(!exists.success)
            {
                return BadRequest(exists.message);
            }

            var register =authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var check = authService.CreateAccessToken(register.data);

            if(!check.success)
            {
                return BadRequest(check.message);
            }
            return Ok(check.data);
        }
    }
}



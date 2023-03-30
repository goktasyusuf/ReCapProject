using Business.Abstract;
using Core.Async.Message;
using Core.Async.RabbitMQ.Publisher.Abstract;
using Entities.Concrete.Dto_s;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMailPublisher mailPublisher;
        ISendEndpointProvider send;

        public AuthController(IAuthService authService, IMailPublisher mailPublisher, ISendEndpointProvider send)
        {
            this.authService = authService;
            this.mailPublisher = mailPublisher;
            this.send = send;
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
            mailPublisher.Publish(userForRegisterDto.Email);
            return Ok(check);
        }

        [HttpPost("resetpassword")]
        public ActionResult ResetPassword(UserForPasswordDto dto)
        {
            var userExists = authService.UserExists(dto.Email);
            if(userExists.Success)
            {
                return BadRequest("Bu maile ait bir kullanıcı bulunmamaktadır");
            }
            var user  = authService.UpdatePassword(dto);
            return Ok(user);
        }

        [HttpGet("deneme")]
        public async Task<ActionResult> Deneme()
        {
            IMessage message = new ExampleMessage { Mail = "selam" };
            var point = await send.GetSendEndpoint(new Uri("queue:ornekkuyruk"));
            await point.Send(message);
            return Ok("mesaj yollandı");
        }
    }
}

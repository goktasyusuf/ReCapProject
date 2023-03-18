using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = userService.GetAll();
            return Ok(values);
        }

        [HttpGet("getuserbyid")]
        public IActionResult GetByUserId(int id)
        {

            var values = userService.GetById(id);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values);

        }
        [HttpPost("updateuser")]
        public IActionResult GetByUserId(UserForUpdate dto)
        {
            var user = userService.GetByMail(dto.EMail);
            user.About = dto.About;
            user.Age = dto.Age;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.About = dto.About;
            user.UserName = dto.UserName;
            var values = userService.Update(user);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values);

        }

    }
}

using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService colorService;

        public ColorsController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            Thread.Sleep(1000);
            var result = colorService.GetAll();
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Color color)
        {
            var result = colorService.Add(color);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

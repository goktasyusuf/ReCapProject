using Business.Abstract;
using Entities.Concrete;
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
            var values = colorService.GetAll();
            return Ok(values);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var values = colorService.Add(color);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = brandService.GetAll();
            return Ok(values);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var values = brandService.Add(brand);
            if(values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
            
        }
    }
}

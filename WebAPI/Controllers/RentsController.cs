using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRentService rentService;

        public RentsController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = rentService.GetAll();
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            Thread.Sleep(5000);
            var result = rentService.GetRentalDetails();

            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = rentService.Add(rental);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = rentService.Delete(rental);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = rentService.GetRentById(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = rentService.Update(rental);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

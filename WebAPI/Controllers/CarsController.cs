using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = carService.GetAll();
            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = carService.Add(car);
            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = carService.GetCarById(carId);
            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarsdetail")]

        public IActionResult GetAllCarsDetails()
        {
            Thread.Sleep(1000);
            var result = carService.GetCarDetails();
            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = carService.GetCarsByBrandId(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = carService.GetCarsByColorId(colorId);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallcarsdetailsbybrandind")]  //GetCarsByCarIdDto

        public IActionResult GetAllCarsDetailsByBrandId(int brandId)
        {
            Thread.Sleep(1000);
            var result = carService.GetCarDetailsByBrandId(brandId);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycoloriddto")]
        public IActionResult GetByColorIdDto(int colorId)
        {
            var result = carService.GetCarDetailsByColorIdDto(colorId);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getcardetailbycariddto")]  

        public IActionResult GetCarsByCarIdDto(int carId)
        {
            Thread.Sleep(1000);
            var result = carService.GetCarsByCarIdDto(carId);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

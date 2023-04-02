using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var values = _carService.GetAll();
            return Ok(values);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car) 
        {
            
            var value = _carService.AddCarAndReturnCarId(car);
            if(value.Success)
            {
                return Ok(value);
            }
            return BadRequest(value.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var values = _carService.GetById(id);
            if(values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var values = _carService.GetCarDetails();
            if(values.Success)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest(values.Message);
            }
        }

        [HttpGet("getcardetailsbybrandid")]
        public IActionResult GetCarDetails(int brandId)
        {

            var values = _carService.GetCarDetailsByBrandId(brandId);
            if (values.Success)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest(values.Message);
            }
        }

        [HttpGet("getcardetailsbycarid")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var values = _carService.GetCarDetailsBycarId(carId);
            if (values.Success)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest(values.Message);
            }
        }

        [HttpGet("getcarsbybrandandcolorid")]
        public IActionResult GetCarsByBrandAndColorId(int brandId,int colorId)
        {
            var values = _carService.GetCarsByBrandAndColorId(brandId,colorId);
            if (values.Success)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest(values.Message);
            }
        }
    }
}

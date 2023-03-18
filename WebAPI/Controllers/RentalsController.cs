using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService rentalService;
        ICarService carService;
        public RentalsController(IRentalService rentalService, ICarService carService)
        {
            this.rentalService = rentalService;
            this.carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = rentalService.GetAll();
            return Ok(values);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            
            var values = rentalService.GetRentalDetails();
            if(values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
            
        }

        [HttpGet("getrentaldetailsbycarid")]
        public IActionResult GetRentalDetails(int carId)
        {
            var values = rentalService.GetRentalDetailsByCarId(carId);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);

        }


        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var values = rentalService.Add(rental);

            var car = carService.GetById(rental.CarId);
            carService.Update(car.Data);

            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);

        }

        [HttpGet("getrentaldetailsbyuserid")]
        public IActionResult GetRentalDetailsByUserId(int userId)
        {
            var values = rentalService.GetRentalDetailsByUserId(userId);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);

        }


    }
}

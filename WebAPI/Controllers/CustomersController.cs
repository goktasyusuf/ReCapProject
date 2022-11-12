using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService customersService;

        public CustomersController(ICustomerService customerService)
        {
            this.customersService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(5000);
            var result = customersService.GetAll();
            if(result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = customersService.Add(customer);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = customersService.Delete(customer);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = customersService.GetById(id);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
           var result = customersService.Update(customer);
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

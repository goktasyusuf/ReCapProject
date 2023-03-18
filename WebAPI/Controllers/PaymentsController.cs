using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }



        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var values = _paymentService.GetPaymentDetails();
            if(values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var values = _paymentService.GetPaymentDetailsByCustomerId(customerId);
            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var values = _paymentService.Add(payment);
            if(values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values);
        }
    }
}

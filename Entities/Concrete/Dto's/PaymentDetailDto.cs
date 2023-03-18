using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto_s
{
    public class PaymentDetailDto : IDto
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public long CreditCardId { get; set; }
        public decimal Amount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}

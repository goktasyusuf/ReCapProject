using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public long CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CVV { get; set; }

    }
}

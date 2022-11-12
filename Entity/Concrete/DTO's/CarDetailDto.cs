using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTO_s
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarDescription { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}

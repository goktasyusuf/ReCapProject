using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto_s
{
    public class CarDetailDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Location { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int FindexScore { get; set; }
        public int SeatNumber { get; set; }
    }
}

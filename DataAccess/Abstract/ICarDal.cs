using Core.DataAccess.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
       List<CarDetailDto> GetCarDetails();
       List<CarDetailDto> GetCarDetailsByBrandId(int brandId);
       List<CarDetailDto> GetCarDetailsByCarId(int carId);
       List<CarDetailDto> GetCarsByBrandAndColor(int brandId,int colorId);
    }
}

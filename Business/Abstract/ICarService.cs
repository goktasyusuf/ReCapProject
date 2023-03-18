using Core.Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService : IGenericService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsBycarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId,int colorId);
        IDataResult<int> AddCarAndReturnCarId(Car car);
    }
}

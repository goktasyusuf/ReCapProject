using Core.DataAccess;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetCarDetailsByColorIdDto(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByCarIdDto(int carId);

    }
}

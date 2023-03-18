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
    public interface IRentalService : IGenericService<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByUserId(int userId);

    }
}

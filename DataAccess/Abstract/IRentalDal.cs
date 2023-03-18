using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailDto> GetRentalDetailsByCarId(int carId);
        List<RentalDetailDto> GetRentalDetailsByUserId(int userId);
    }
}

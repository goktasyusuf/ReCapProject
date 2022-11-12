using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete.DTO_s;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}

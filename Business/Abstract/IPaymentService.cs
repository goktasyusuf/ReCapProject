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
    public interface IPaymentService : IGenericService<Payment>
    {
        IDataResult<List<PaymentDetailDto>> GetPaymentDetails();
        IDataResult<List<PaymentDetailDto>> GetPaymentDetailsByCustomerId(int customerId);
    }
}

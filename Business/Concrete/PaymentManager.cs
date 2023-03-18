using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment entity)
        {
            _paymentDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(x => x.Id == id));
        }

        public IDataResult<List<PaymentDetailDto>> GetPaymentDetails()
        {
            return new SuccessDataResult<List<PaymentDetailDto>>(_paymentDal.GetPaymentDetails());
        }

        public IDataResult<List<PaymentDetailDto>> GetPaymentDetailsByCustomerId(int customerId)
        {
           return new SuccessDataResult<List<PaymentDetailDto>>(_paymentDal.GetPaymentDetailsByCustomerId(customerId));
        }

        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult();
        }
    }
}

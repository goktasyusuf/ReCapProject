using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfRepositoryBase<Payment, AppDbContext>, IPaymentDal
    {
        public List<PaymentDetailDto> GetPaymentDetails()
        {
            using (var context = new AppDbContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers on user.Id equals customer.UserId
                             join payment in context.Payments on customer.Id equals payment.CustomerId
                             select new PaymentDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 CreditCardId = payment.CreditCardId,
                                 CustomerId = customer.Id,
                                 Email = user.EMail,
                                 FirstName= user.FirstName,
                                 LastName= user.LastName,
                                 PaymentId = payment.Id,
                                 UserId = user.Id,
                             };
                return result.ToList();
            }
        }

        public List<PaymentDetailDto> GetPaymentDetailsByCustomerId(int customerId)
        {
            using (var context = new AppDbContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers on user.Id equals customer.UserId
                             join payment in context.Payments on customer.Id equals payment.CustomerId where user.Id == customerId
                             select new PaymentDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 CreditCardId = payment.CreditCardId,
                                 CustomerId = customer.Id,
                                 Email = user.EMail,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 PaymentId = payment.Id,
                                 UserId = user.Id,
                             };
                return result.ToList();
            }
        }
    }
}

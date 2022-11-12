using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal CustomerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            CustomerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            CustomerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            CustomerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(CustomerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            return new SuccessDataResult<List<Customer>>(CustomerDal.GetAll(c => c.CustomerId == id));
        }

        public IResult Update(Customer customer)
        {
            CustomerDal.Update(customer);
            return new SuccessResult();
        }
    }
}

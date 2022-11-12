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
    public class BrandManager : IBrandService
    {

        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            brandDal.Add(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll());
        }
    }
}

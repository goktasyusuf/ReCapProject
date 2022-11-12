using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DTO_s;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {

        IRentalDal RentalDal;

        public RentManager(IRentalDal rentalDal)
        {
            RentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = RentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate != null);

            if(result == null)
            {
                return new ErrorResult("Öyle bir araba yok vey return date null !");
            }
            rental.RentDate = DateTime.Now;
            RentalDal.Add(rental);
            return new SuccessResult("Kiralandı");
        }

        public IResult Delete(Rental rental)
        {
            RentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(RentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(RentalDal.GetRentalDetails().data);
        }

        public IDataResult<List<Rental>> GetRentById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(RentalDal.GetAll(r => r.RentalId == rentalId));
        }

        public IResult Update(Rental rental)
        {
            RentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}

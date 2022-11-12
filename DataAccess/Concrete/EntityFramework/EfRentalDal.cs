using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DTO_s;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RealRecapDataBaseContext>, IRentalDal
    {
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            using (var context = new RealRecapDataBaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentalId = rental.RentalId,
                                 RentDate = (DateTime)rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return new SuccessDataResult<List<RentalDetailDto>>(result.ToList());
            }
        }
    }
}

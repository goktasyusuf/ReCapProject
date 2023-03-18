using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System.Runtime.ConstrainedExecution;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfRepositoryBase<Rental, AppDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new AppDbContext())
            {
                var result = from rental in context.Rentals
                             join user in context.Users on rental.UserId equals user.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.Id
                             select new RentalDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear

                             };
                return result.ToList();
            }

        }

        public List<RentalDetailDto> GetRentalDetailsByCarId(int carId)
        {
            using (var context = new AppDbContext())
            {
                var result = from rental in context.Rentals
                             join user in context.Users on rental.UserId equals user.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.Id
                             where car.Id == carId
                             select new RentalDetailDto 
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear

                             };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsByUserId(int userId)
        {
            using (var context = new AppDbContext())
            {
                var result = from rental in context.Rentals
                             join user in context.Users on rental.UserId equals user.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.Id
                             where user.Id == userId
                             select new RentalDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarId = car.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear

                             };
                return result.ToList();
            }

        }
    }
}

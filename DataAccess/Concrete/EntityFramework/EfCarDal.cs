using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, AppDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (var context = new AppDbContext())
            {

                var rentals = context.Rentals;

                foreach (var item in rentals.ToList())
                {
                    if (item.ReturnDate < DateTime.Now) 
                    { 
                        rentals.Remove(item);
                        context.SaveChanges();
                    }
                }
                var result = from c in context.Cars
                             join r in context.Rentals on c.Id equals r.CarId into temp from t in temp.DefaultIfEmpty()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where t.CarId != c.Id 
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Location = c.Location,
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber,

                             }; 
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (var context = new AppDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals on c.Id equals r.CarId into temp
                             from t in temp.DefaultIfEmpty()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where b.BrandId == brandId && t.CarId != c.Id
                             select new CarDetailDto
                             {
                                 Location = c.Location,
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.BrandId,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (var context = new AppDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals on c.Id equals r.CarId into temp from t in temp.DefaultIfEmpty()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where c.Id == carId && t.CarId != c.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Location = c.Location,
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber
                             };   
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandAndColor(int brandId, int colorId)
        {
            using (var context = new AppDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals on c.Id equals r.CarId into temp
                             from t in temp.DefaultIfEmpty()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where clr.Id == colorId && b.BrandId == brandId && t.CarId != c.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 CarId = c.Id,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Location = c.Location,
                                 ModelYear = c.ModelYear,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber
                             };
                return result.ToList();
            }
        }
    }
}


/*
       public List<CarDetailDto> GetCarDetails()
        {
            using (var context  = new AppDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join rental in context.Rentals on c.Id equals rental.CarId
                             join clr in context.Colors on c.ColorId equals clr.Id where c.IsRented == false
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Location = c.Location,
                                 CarId = c.Id,
                                 BrandId= b.BrandId,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber,
                                 

                             };
                return result.ToList();
            }
        }
 
 
 
 */


/*
 * public List<CarDetailDto> GetCarDetails()
        {
            using (var context = new AppDbContext())
            {

                var rentals =  context.Rentals.ToList();


                var result = from c in context.Cars
                             join r in context.Rentals on c.Id equals r.CarId into temp from t in temp.DefaultIfEmpty()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where t.CarId != c.Id 
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Location = c.Location,
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 FindexScore = c.FindexScore,
                                 SeatNumber = c.SeatNumber,

                             };
                return result.ToList();
            }
        }
 
 
 
 
 */
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RealRecapDataBaseContext>, ICarDal
    {
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            using (RealRecapDataBaseContext context = new RealRecapDataBaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarDescription = c.Description,
                                 CarId = c.CarId,
                                 ColorName = cl.ColorName
                             };

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            using (RealRecapDataBaseContext context = new RealRecapDataBaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId where b.BrandId == brandId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarDescription = c.Description,
                                 CarId = c.CarId,
                                 ColorName = cl.ColorName
                             };

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorIdDto(int colorId)
        {
            using (RealRecapDataBaseContext context = new RealRecapDataBaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             where cl.ColorId == colorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarDescription = c.Description,
                                 CarId = c.CarId,
                                 ColorName = cl.ColorName
                             };

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsByCarIdDto(int carId)
        {
            using (RealRecapDataBaseContext context = new RealRecapDataBaseContext())
            {
                var result = (from c in context.Cars
                              join b in context.Brands on c.BrandId equals b.BrandId
                              join cl in context.Colors on c.ColorId equals cl.ColorId
                              where c.CarId == carId
                              select new CarDetailDto
                              {
                                  BrandName = b.BrandName,
                                  CarDescription = c.Description,
                                  CarId = c.CarId,
                                  ColorName = cl.ColorName
                              });

                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
            }
        }
    }
}

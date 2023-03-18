using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager cm = new CarManager(new EfCarDal());

            foreach (var item in cm.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + " " + item.ColorName + " " + item.BrandName);
            }
        }
    }
}
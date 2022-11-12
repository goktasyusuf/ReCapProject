using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {

        List<Color> colors;

        public InMemoryColorDal()
        {
            colors = new List<Color>();
        }
        public void Add(Color entity)
        {
            colors.Add(entity);
        }

        public void Delete(Color entity)
        {
            Color temp = colors.SingleOrDefault(p => p.ColorId == entity.ColorId);
            colors.Remove(temp);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return colors.AsQueryable().SingleOrDefault(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return filter == null ? colors.ToList() : colors.AsQueryable().Where(filter).ToList();
        }

        public void Update(Color entity)
        {
            Color temp = colors.SingleOrDefault(p => p.ColorId == entity.ColorId);
            temp.ColorName = entity.ColorName;
            Console.WriteLine(temp.ColorName + " güncellendi");
        }
    }
}

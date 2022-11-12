using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entity.Concrete.Color;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            colorDal.Add(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll());
        }
    }
}

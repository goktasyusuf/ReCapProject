using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entity.Concrete.Color;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);

        IDataResult<List<Color>> GetAll();
    }
}

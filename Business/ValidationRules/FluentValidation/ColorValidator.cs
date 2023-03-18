using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Renk ismi boş geçilemez");
            RuleFor(x=>x.Name).Must(CheckIfSameNameExists).WithMessage("Aynı isimde renk olamaz");
        }

        private bool CheckIfSameNameExists(string arg)
        {
            using (var context = new AppDbContext())
            {
                var colors = context.Colors.ToList();
                foreach (var item in colors)
                {
                    if(item.Name.ToString() == arg)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

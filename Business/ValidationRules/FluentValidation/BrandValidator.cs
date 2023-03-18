using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x=>x.BrandName).NotEmpty().WithMessage("Marka ismi boş geçilemez");
            RuleFor(x => x.BrandName).Must(CheckIfNameExists).WithMessage("Aynı isimde marka ismi olamaz");

        }


        private  bool CheckIfNameExists(string arg)
        {
            using (var context = new AppDbContext())
            {
                var brands = context.Brands.ToList();
                foreach (var item in brands)
                {
                    if(item.BrandName.ToString() == arg)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

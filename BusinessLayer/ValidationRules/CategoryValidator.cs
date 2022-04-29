using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adı en fazla 50 Karakter Olmalı");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Olamaz");
            RuleFor(x => x.CategoryDescription).MaximumLength(100).WithMessage("Açıklama en fazla 100 Karakter Olmalı");
        }
    }
}

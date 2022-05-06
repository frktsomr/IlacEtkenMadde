using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kulanıcı Adı Boş Olamaz");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Kulanıcı Soyadı Boş Olamaz");
        }

    }
}

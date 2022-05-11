using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz.");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz. ");
            RuleFor(x => x.ContactMessage).MinimumLength(20).WithMessage("Mesaj en az 20 Karakter Olmalı");
            RuleFor(x => x.ContactSubject).MaximumLength(100).WithMessage("Konu adı en fazla 100 Karakter Olmalı");
        }
    }
}

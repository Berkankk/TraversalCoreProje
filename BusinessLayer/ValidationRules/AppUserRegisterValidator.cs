using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen bu alanı doldurunuz");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Lütfen en az 4 karakterlik bir kullanıcı adı yazınız");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor");
        }
    }
}

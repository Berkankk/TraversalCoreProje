using DTOLayer.DTOs.AnnouncementDTO;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik veri girişi yapın");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Lütfen en az 10 karakterlik veri girişi yapın");
        }
    }
}

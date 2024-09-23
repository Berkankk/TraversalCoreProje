using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
        }
    }
}

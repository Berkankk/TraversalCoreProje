using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bu alanı doldurun");
        }
    }
}

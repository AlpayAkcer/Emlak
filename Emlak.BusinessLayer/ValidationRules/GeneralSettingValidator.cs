using Emlak.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class GeneralSettingValidator : AbstractValidator<GeneralSetting>
    {
        public GeneralSettingValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Email")
                .WithMessage("Email Boş Bırakmayınız");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Adres")
                .WithMessage("İlan Adresini Boş Bırakmayınız");

            RuleFor(x => x.ImageName)
                .NotEmpty()
                .WithName("İmageName")
                .WithMessage("Resim Alanını Boş Bırakmayınız");

            RuleFor(x => x.Phone).Matches(new Regex(@"(^(\+90|0)?\s*(\(\d{3}\)[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}|\(\d{3}\)[\s-]*\d{3}[\s-]*\d{4}|\(\d{3}\)[\s-]*\d{7}|\d{3}[\s-]*\d{3}[\s-]*\d{4}|\d{3}[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2})$)"));
        }
    }
}

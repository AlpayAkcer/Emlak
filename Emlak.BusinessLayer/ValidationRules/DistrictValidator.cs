using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class DistrictValidator : AbstractValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(x => x.DistrictName)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("İlçe Adı")
                .WithMessage("İlçe Başlığını Boş Bırakmayınız");
        }
    }
}

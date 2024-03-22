using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class AdvertTypeValidator : AbstractValidator<AdvertType>
    {
        public AdvertTypeValidator()
        {
            RuleFor(x => x.AdvertTypeName)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Tür")
                .WithMessage("Tür Başlığını Boş Bırakmayınız");
        }
    }
}

using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class SituationValidator : AbstractValidator<Situation>
    {
        public SituationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Durum")
                .WithMessage("Durum Başlığını Boş Bırakmayınız");
        }
    }
}

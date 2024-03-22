using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class NeighbourhoodValidator : AbstractValidator<Neighbourhood>
    {
        public NeighbourhoodValidator()
        {
            RuleFor(x => x.NeighbourhoodName)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Mahalle Adı")
                .WithMessage("Mahalle Başlığını Boş Bırakmayınız");
        }
    }
}

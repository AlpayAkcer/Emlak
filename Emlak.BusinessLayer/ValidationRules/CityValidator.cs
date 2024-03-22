using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Şehir Adı")
                .WithMessage("Şehir Başlığını Boş Bırakmayınız");
        }
    }
}

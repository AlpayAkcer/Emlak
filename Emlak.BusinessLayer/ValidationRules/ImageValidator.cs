using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Images>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImageName)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Resim Adı")
                .WithMessage("Resim Başlığını Boş Bırakmayınız");
        }
    }
}

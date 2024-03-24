using Emlak.EntityLayer.Entities;
using FluentValidation;

namespace Emlak.BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Images>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImageUrl.Name)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Resim Adı")
                .WithMessage("Resim Başlığını Boş Bırakmayınız");
        }
    }
}

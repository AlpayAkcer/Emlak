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
    public class AdvertValidator : AbstractValidator<Advert>
    {
        public AdvertValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Başlık")
                .WithMessage("İlan Başlığını Boş Bırakmayınız");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(1)
                .WithName("Adres")
                .WithMessage("İlan Adresini Boş Bırakmayınız");

            RuleFor(x => x.AirCordinator)
                .NotEmpty()
                .WithName("Klima")
                .WithMessage("Klima Alanını Boş Bırakmayınız");

            RuleFor(x => x.Area)
                .NotEmpty()
                .WithName("Alan m2")
                .WithMessage("Alan Alanını Boş Bırakmayınız");

            RuleFor(x => x.BathOfRoomNumber)
                .NotEmpty()
                .WithName("Banyo Sayısı")
                .WithMessage("Banyo Alanını Boş Bırakmayınız");

            RuleFor(x => x.NumberOfRoom)
                .NotEmpty()
                .WithName("Oda Sayısı")
                .WithMessage("Oda Alanını Boş Bırakmayınız");

            RuleFor(x => x.Floor)
                .NotEmpty()
                .WithName("Kat Sayısı")
                .WithMessage("Kat Alanını Boş Bırakmayınız");

            RuleFor(x => x.Garage)
                .NotEmpty()
                .WithName("Garaj Sayısı")
                .WithMessage("Garaj Alanını Boş Bırakmayınız");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithName("Fiyat")
                .WithMessage("Fiyat Alanını Boş Bırakmayınız");

            RuleFor(x => x.CityID)
                .NotEmpty()
                .WithName("Şehir")
                .WithMessage("Şehir Alanını Boş Bırakmayınız");
            RuleFor(x => x.DistrictID)
                .NotEmpty()
                .WithName("İlçe")
                .WithMessage("İlçe Alanını Boş Bırakmayınız");
            RuleFor(x => x.NeighbourhoodID)
                .NotEmpty()
                .WithName("Mahalle")
                .WithMessage("Mahalle Alanını Boş Bırakmayınız");

            RuleFor(x => x.SituationID)
                .NotEmpty()
                .WithName("Durum")
                .WithMessage("Durum Alanını Boş Bırakmayınız");

            RuleFor(x => x.Pool)
                .NotEmpty()
                .WithName("Havuz")
                .WithMessage("Havuz Alanını Boş Bırakmayınız");

            RuleFor(x => x.PhoneNumber).Matches(new Regex(@"(^(\+90|0)?\s*(\(\d{3}\)[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}|\(\d{3}\)[\s-]*\d{3}[\s-]*\d{4}|\(\d{3}\)[\s-]*\d{7}|\d{3}[\s-]*\d{3}[\s-]*\d{4}|\d{3}[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2})$)"));
        }
    }
}

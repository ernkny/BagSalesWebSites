using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidation
{
    public class BagValidator:AbstractValidator<Bag>
    {
        public BagValidator()
        {
            RuleFor(b => b.Model).NotNull().NotEmpty().MaximumLength(200).WithMessage("Lütfen Daha Kısa Molel Bilgisi Giriniz!");
            RuleFor(b => b.Title).NotNull().NotEmpty().MaximumLength(200).WithMessage("Lütfen Daha Kısa Başlık Giriniz!");
            RuleFor(b => b.Description).NotNull().NotEmpty().WithMessage("Lütfen Açıklamayı Boş Bırakmayınız!");
            RuleFor(b => b.Keywords).NotNull().NotEmpty().WithMessage("Lütfen SEO İçin Uygun Kelimeler Giriniz!");
            RuleFor(b => b.Price).NotEmpty().NotNull().WithMessage("Lütfen Fiyatını Giriniz!");
            RuleFor(b => b.Showcase).NotEmpty().NotNull();
        }
    }
}

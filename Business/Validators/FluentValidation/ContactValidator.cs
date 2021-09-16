using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidation
{
    class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(b => b.FirstName).NotNull().NotEmpty();
            RuleFor(b => b.SurName).NotNull().NotEmpty();
            RuleFor(b => b.Messages).NotNull().NotEmpty();
            RuleFor(b => b.Email).NotNull().NotEmpty();
            RuleFor(b => b.Address).NotEmpty().NotNull();
            RuleFor(b => b.Country).NotEmpty().NotNull();
        }
    }
}

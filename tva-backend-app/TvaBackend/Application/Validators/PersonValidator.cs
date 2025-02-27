using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.IdNumber).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}

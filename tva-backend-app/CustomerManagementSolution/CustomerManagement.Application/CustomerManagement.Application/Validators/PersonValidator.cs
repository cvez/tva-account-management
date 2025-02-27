using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Validators
{
    public class PersonValidator : AccountValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(p => p.IdNumber).NotEmpty().Length(13);
            RuleFor(p => p.Name).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Surname).NotEmpty().MaximumLength(50);
        }

    }
}

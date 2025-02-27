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
    public class AccountValidator : AccountValidator<AccountDto>
    {
        public AccountValidator()
        {
            RuleFor(a => a.AccountNumber).NotEmpty().Length(10);
            RuleFor(a => a.OutstandingBalance).GreaterThanOrEqualTo(0); 
            RuleFor(a => a.PersonCode).NotEmpty();
        }
    }
}

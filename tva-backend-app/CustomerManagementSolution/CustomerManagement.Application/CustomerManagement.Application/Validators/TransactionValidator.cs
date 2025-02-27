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
    public class TransactionValidator : AccountValidator<TransactionDto>
    {
        public TransactionValidator()
        {
            RuleFor(t => t.TransactionDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(t => t.Amount).NotEqual(0);
            RuleFor(t => t.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.AccountCode).NotEmpty();
        }
    }
}

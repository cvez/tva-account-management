using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionDto>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Amount).NotEqual(0);
            RuleFor(x => x.TransactionDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.AccountCode).NotEmpty();
        }
    }
}

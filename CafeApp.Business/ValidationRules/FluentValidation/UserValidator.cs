using CafeApp.Entities.Concrete.Tables;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Surname).MaximumLength(100);
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.HashPassword).NotNull().NotEmpty();
            RuleFor(x => x.SaltPassword).NotNull().NotEmpty().MaximumLength(20);
        }
    }
}

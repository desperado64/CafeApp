using CafeApp.Entities.Concrete.Tables;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.ValidationRules.FluentValidation
{
    public class PropertyValidator : AbstractValidator<Property>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.Key).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.Value).NotNull().NotEmpty().MaximumLength(150);
        }
    }
}
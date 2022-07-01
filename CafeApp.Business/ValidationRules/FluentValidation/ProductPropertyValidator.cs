using CafeApp.Entities.Concrete.Tables;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Business.ValidationRules.FluentValidation
{
    public class ProductPropertyValidator : AbstractValidator<ProductProperty>
    {
        public ProductPropertyValidator()
        {
            RuleFor(x => x.PropertyID).GreaterThan(0);
            RuleFor(x => x.ProductID).GreaterThan(0);
        }
    }
}

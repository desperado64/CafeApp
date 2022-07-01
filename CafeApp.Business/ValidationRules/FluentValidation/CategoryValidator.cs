using CafeApp.Entities.Concrete.Tables;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty().MaximumLength(100);
            //    RuleFor(x => x.ParentCategoryID).GreaterThanOrEqualTo(0);
            RuleFor(x => x.IsDeleted).NotNull();  
        }
    }
}

using CafeApp.Entities.Concrete.Tables;
using FluentValidation;

namespace CafeApp.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.CategoryID).NotNull().GreaterThan(0);
            RuleFor(x => x.Price).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.ImagePath);
        }
    }
}
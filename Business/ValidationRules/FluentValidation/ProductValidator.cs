using FluentValidation;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .MinimumLength(3)
            .MaximumLength(30)
            .WithMessage("Product name must contain between 3-30 characters.");

        RuleFor(product => product.Name)
            .NotNull()
            .WithMessage("Product name can not be empty.");

        RuleFor(product => product.Price)
            .NotNull().
            WithMessage("Product price can not be empty.");

        RuleFor(product => product.Price)
            .GreaterThan(0)
            .WithMessage("Product price can not set as under 0.");

        RuleFor(product => product.ImagePath)
            .NotNull()
            .WithMessage("Product Image Path can not be empty.");
    }
}
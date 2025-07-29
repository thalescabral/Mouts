using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(x => x.Customer)
            .NotEmpty().WithMessage("Customer is required.");

        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch is required.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("At least one sale item is required.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                .LessThanOrEqualTo(20).WithMessage("You cannot sell more than 20 items of the same product.");

            items.RuleFor(i => i.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        });
    }
}
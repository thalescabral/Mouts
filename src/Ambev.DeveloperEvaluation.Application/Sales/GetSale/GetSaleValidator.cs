using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale Id must not be empty.");
    }
}

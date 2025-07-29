using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator para CreateSaleRequest definindo as regras de validação para criação de uma venda.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("SaleNumber é obrigatório.")
                .Length(1, 20).WithMessage("SaleNumber deve ter até 20 caracteres.");

            RuleFor(sale => sale.Date)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date não pode ser no futuro.");

            RuleFor(sale => sale.Customer)
                .NotEmpty().WithMessage("Customer é obrigatório.")
                .MaximumLength(100).WithMessage("Customer deve ter no máximo 100 caracteres.");

            RuleFor(sale => sale.Branch)
                .NotEmpty().WithMessage("Branch é obrigatório.")
                .MaximumLength(50).WithMessage("Branch deve ter no máximo 50 caracteres.");

            RuleFor(sale => sale.Status)
                .IsInEnum().WithMessage("Status inválido.")
                .Must(s => s != SaleStatus.Unknown) // supondo que existe um valor Unknown
                .WithMessage("Status não pode ser 'Unknown'.");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");

            RuleForEach(sale => sale.Items).SetValidator(new SaleItemRequestValidator());
        }
    }

    /// <summary>
    /// Validator para itens da venda.
    /// </summary>
    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemRequestValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("ProductId é obrigatório.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity deve ser maior que zero.");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("UnitPrice deve ser maior que zero.");
        }
    }
}

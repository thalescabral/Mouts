using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid Id { get; set; }
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public Guid SaleId { get; set; }
    public Sale Sale { get; set; } = null!;

    public decimal Total => Quantity * UnitPrice * (1 - Discount);

    public SaleItem() { }

    public SaleItem(string productId, int quantity, decimal unitPrice, decimal discount)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
    }
}


using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Customer { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public List<SaleItem> Items { get; set; } = new();
    public bool IsCancelled { get; set; }

    public decimal Total => Items.Sum(i => i.Total);

    public void AddItem(string productId, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new DomainException("Cannot sell more than 20 items");

        var discount = 0m;
        if (quantity >= 10) discount = 0.20m;
        else if (quantity >= 4) discount = 0.10m;

        var item = new SaleItem(productId, quantity, unitPrice, discount);
        Items.Add(item);
    }

    public void Cancel() => IsCancelled = true;
}



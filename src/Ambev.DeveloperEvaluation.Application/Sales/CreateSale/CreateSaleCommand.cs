using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;



namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string SaleNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Customer { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public List<CreateSaleItem> Items { get; set; } = new();

        public class CreateSaleItem
        {
            public string ProductId { get; set; } = null!;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }

}
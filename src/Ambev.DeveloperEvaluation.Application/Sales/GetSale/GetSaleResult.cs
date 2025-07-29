using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Response model for GetSale operation
    /// </summary>
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The sale number
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date when the sale was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The customer identifier or description
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// The branch where the sale was made
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// The total amount of the sale
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Indicates if the sale was cancelled
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// The list of items in the sale
        /// </summary>
        public List<GetSaleItemResult> Items { get; set; } = new();
    }

    /// <summary>
    /// Sale item details in the GetSaleResult response
    /// </summary>
    public class GetSaleItemResult
    {
        /// <summary>
        /// The product identifier
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The product description
        /// </summary>
        public string ProductDescription { get; set; } = string.Empty;

        /// <summary>
        /// Quantity sold of the product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied on this item (0 to 1)
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total amount for this item after discount
        /// </summary>
        public decimal Total { get; set; }
    }
}

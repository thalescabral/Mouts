using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// API response model for GetSale operation
    /// </summary>
    public class GetSaleResponse
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The sale number or code
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date when the sale was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The customer name or identifier related to the sale
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// The branch or store where the sale was made
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// The status of the sale (e.g., Completed, Cancelled)
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// The total amount of the sale
        /// </summary>
        public decimal Total { get; set; }
    }
}

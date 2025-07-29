using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The sale number (identificação legível da venda)
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the sale was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The customer name or identifier
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// The branch or store where the sale occurred
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// The current status of the sale
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// The total value of the sale
        /// </summary>
        public decimal Total { get; set; }
    }
}

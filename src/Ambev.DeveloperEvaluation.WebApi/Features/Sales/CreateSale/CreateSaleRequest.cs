using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Representa uma requisição para criar uma nova venda.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Número da venda (identificador comercial, pode ser string).
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora da venda.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Filial onde a venda foi realizada.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Status da venda (ex: Ativa, Cancelada).
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Lista de itens vendidos.
        /// </summary>
        public List<SaleItemRequest> Items { get; set; } = new();
    }

    /// <summary>
    /// Representa um item da venda.
    /// </summary>
    public class SaleItemRequest
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade vendida.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Preço unitário no momento da venda.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}

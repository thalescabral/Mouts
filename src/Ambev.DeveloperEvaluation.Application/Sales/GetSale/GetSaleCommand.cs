using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommand : IRequest<GetSaleResult>
{
    public Guid Id { get; set; }
}

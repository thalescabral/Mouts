namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

using MediatR;
using System;

public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    public Guid Id { get; set; }

    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}
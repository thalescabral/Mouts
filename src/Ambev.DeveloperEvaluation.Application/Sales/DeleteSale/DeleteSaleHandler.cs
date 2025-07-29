using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
    {
        private readonly ISaleRepository _repository;

        public DeleteSaleHandler(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteSaleResponse?> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (sale == null)
                return null; // Retorna null se não encontrar a venda

            await _repository.DeleteAsync(sale.Id, cancellationToken);

            return new DeleteSaleResponse
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber
            };
        }

    }
}

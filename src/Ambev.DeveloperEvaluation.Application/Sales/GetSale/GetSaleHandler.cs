using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSaleHandler> _logger;

    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (sale == null)
        {
            _logger.LogWarning("Sale with ID {SaleId} not found.", request.Id);
            return null!;
            // Ou lançar exceção, ou usar Result com sucesso/falha conforme padrão da sua solução
        }

        var result = _mapper.Map<GetSaleResult>(sale);
        return result;
    }
}
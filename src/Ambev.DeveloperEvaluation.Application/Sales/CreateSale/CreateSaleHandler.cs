using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSaleCommand> _validator;

    public CreateSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper,
        IValidator<CreateSaleCommand> validator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var sale = new Sale
        {
            SaleNumber = request.SaleNumber,
            Date = request.Date,
            Customer = request.Customer,
            Branch = request.Branch
        };

        foreach (var item in request.Items)
        {
            sale.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
        }

        await _saleRepository.CreateAsync(sale, cancellationToken);

        Console.WriteLine($"Event: SaleCreated - {sale.SaleNumber}");

        var result = _mapper.Map<CreateSaleResult>(sale);
        return result;
    }
}

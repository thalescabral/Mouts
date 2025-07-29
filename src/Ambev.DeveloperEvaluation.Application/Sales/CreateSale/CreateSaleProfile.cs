using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.IsCancelled, opt => opt.Ignore()); // Default false na criação

        CreateMap<CreateSaleCommand.CreateSaleItem, SaleItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Total, opt => opt.Ignore())
            .ForMember(dest => dest.Discount, opt => opt.Ignore());

        CreateMap<Sale, CreateSaleResult>()
            .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => src.IsCancelled));

        CreateMap<SaleItem, SaleItemResult>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductDescription, opt => opt.Ignore()) // Preencher manualmente se precisar
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));
    }
}
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            // Mapeia Guid para comando (já existente)
            CreateMap<Guid, Application.Sales.GetSale.GetSaleCommand>()
                .ConstructUsing(id => new Application.Sales.GetSale.GetSaleCommand { Id = id });

            // Mapeia o resultado da aplicação para a resposta da API (Falta isso!)
            CreateMap<Application.Sales.GetSale.GetSaleResult, GetSaleResponse>();
        }
    }
}
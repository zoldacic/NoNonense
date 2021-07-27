using AutoMapper;
using NoNonense.Application.Features.Products.Commands.AddEdit;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}
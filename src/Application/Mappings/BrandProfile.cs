using AutoMapper;
using NoNonense.Application.Features.Brands.Commands.AddEdit;
using NoNonense.Application.Features.Brands.Queries.GetAll;
using NoNonense.Application.Features.Brands.Queries.GetById;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}
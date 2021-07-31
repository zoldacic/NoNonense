using AutoMapper;
using NoNonense.Application.Features.Tags.Commands.AddEdit;
using NoNonense.Application.Features.Tags.Queries.GetAll;
using NoNonense.Application.Features.Tags.Queries.GetById;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Mappings
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<AddEditTagCommand, Tag>().ReverseMap();
            CreateMap<GetTagByIdResponse, Tag>().ReverseMap();
            CreateMap<GetAllTagsResponse, Tag>().ReverseMap();
        }
    }
}
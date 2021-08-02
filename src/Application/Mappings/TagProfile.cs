using AutoMapper;
using NowWhat.Application.Features.Tags.Commands.AddEdit;
using NowWhat.Application.Features.Tags.Queries.GetAll;
using NowWhat.Application.Features.Tags.Queries.GetById;
using NowWhat.Domain.Entities.Catalog;

namespace NowWhat.Application.Mappings
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
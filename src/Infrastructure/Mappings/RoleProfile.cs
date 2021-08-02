using AutoMapper;
using NowWhat.Infrastructure.Models.Identity;
using NowWhat.Application.Responses.Identity;

namespace NowWhat.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}
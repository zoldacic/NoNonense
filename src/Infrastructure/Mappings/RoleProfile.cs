using AutoMapper;
using NoNonense.Infrastructure.Models.Identity;
using NoNonense.Application.Responses.Identity;

namespace NoNonense.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}
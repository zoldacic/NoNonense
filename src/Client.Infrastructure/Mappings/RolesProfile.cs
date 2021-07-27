using AutoMapper;
using NoNonense.Application.Requests.Identity;
using NoNonense.Application.Responses.Identity;

namespace NoNonense.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}
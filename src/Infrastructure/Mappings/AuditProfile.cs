using AutoMapper;
using NoNonense.Infrastructure.Models.Audit;
using NoNonense.Application.Responses.Audit;

namespace NoNonense.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}
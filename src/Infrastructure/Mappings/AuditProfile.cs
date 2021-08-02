using AutoMapper;
using NowWhat.Infrastructure.Models.Audit;
using NowWhat.Application.Responses.Audit;

namespace NowWhat.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}
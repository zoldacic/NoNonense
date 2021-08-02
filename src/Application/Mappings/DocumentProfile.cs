using AutoMapper;
using NowWhat.Application.Features.Documents.Commands.AddEdit;
using NowWhat.Application.Features.Documents.Queries.GetById;
using NowWhat.Domain.Entities.Misc;

namespace NowWhat.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}
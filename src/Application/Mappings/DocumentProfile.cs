using AutoMapper;
using NoNonense.Application.Features.Documents.Commands.AddEdit;
using NoNonense.Application.Features.Documents.Queries.GetById;
using NoNonense.Domain.Entities.Misc;

namespace NoNonense.Application.Mappings
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
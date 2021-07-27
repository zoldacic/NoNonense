using AutoMapper;
using NoNonense.Application.Features.DocumentTypes.Commands.AddEdit;
using NoNonense.Application.Features.DocumentTypes.Queries.GetAll;
using NoNonense.Application.Features.DocumentTypes.Queries.GetById;
using NoNonense.Domain.Entities.Misc;

namespace NoNonense.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}
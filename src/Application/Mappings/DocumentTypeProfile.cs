using AutoMapper;
using NowWhat.Application.Features.DocumentTypes.Commands.AddEdit;
using NowWhat.Application.Features.DocumentTypes.Queries.GetAll;
using NowWhat.Application.Features.DocumentTypes.Queries.GetById;
using NowWhat.Domain.Entities.Misc;

namespace NowWhat.Application.Mappings
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
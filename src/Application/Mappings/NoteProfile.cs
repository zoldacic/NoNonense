using AutoMapper;
using NoNonense.Application.Features.Notes.Commands.AddEdit;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddEditNoteCommand, Note>().ReverseMap();
        }
    }
}
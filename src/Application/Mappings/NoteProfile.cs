using AutoMapper;
using NowWhat.Application.Features.Notes.Commands.AddEdit;
using NowWhat.Domain.Entities.Catalog;

namespace NowWhat.Application.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddEditNoteCommand, Note>().ReverseMap();
        }
    }
}
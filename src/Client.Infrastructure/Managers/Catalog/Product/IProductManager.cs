using NowWhat.Application.Features.Notes.Commands.AddEdit;
using NowWhat.Application.Features.Notes.Queries.GetAllPaged;
using NowWhat.Application.Requests.Catalog;
using NowWhat.Shared.Wrapper;
using System.Threading.Tasks;

namespace NowWhat.Client.Infrastructure.Managers.Catalog.Note
{
    public interface INoteManager : IManager
    {
        Task<PaginatedResult<GetAllPagedNotesResponse>> GetNotesAsync(GetAllPagedNotesRequest request);

        Task<IResult<string>> GetNoteImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditNoteCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
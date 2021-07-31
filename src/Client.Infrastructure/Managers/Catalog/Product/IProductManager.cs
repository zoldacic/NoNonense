using NoNonense.Application.Features.Notes.Commands.AddEdit;
using NoNonense.Application.Features.Notes.Queries.GetAllPaged;
using NoNonense.Application.Requests.Catalog;
using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;

namespace NoNonense.Client.Infrastructure.Managers.Catalog.Note
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
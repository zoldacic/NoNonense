using NowWhat.Application.Features.Notes.Commands.AddEdit;
using NowWhat.Application.Features.Notes.Queries.GetAllPaged;
using NowWhat.Application.Requests.Catalog;
using NowWhat.Client.Infrastructure.Extensions;
using NowWhat.Shared.Wrapper;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NowWhat.Client.Infrastructure.Managers.Catalog.Note
{
    public class NoteManager : INoteManager
    {
        private readonly HttpClient _httpClient;

        public NoteManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.NotesEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.NotesEndpoints.Export
                : Routes.NotesEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<string>> GetNoteImageAsync(int id)
        {
            var response = await _httpClient.GetAsync(Routes.NotesEndpoints.GetNoteImage(id));
            return await response.ToResult<string>();
        }

        public async Task<PaginatedResult<GetAllPagedNotesResponse>> GetNotesAsync(GetAllPagedNotesRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.NotesEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            return await response.ToPaginatedResult<GetAllPagedNotesResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditNoteCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.NotesEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
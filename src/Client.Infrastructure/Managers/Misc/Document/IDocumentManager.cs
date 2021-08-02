using NowWhat.Application.Features.Documents.Commands.AddEdit;
using NowWhat.Application.Features.Documents.Queries.GetAll;
using NowWhat.Application.Requests.Documents;
using NowWhat.Shared.Wrapper;
using System.Threading.Tasks;
using NowWhat.Application.Features.Documents.Queries.GetById;

namespace NowWhat.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}
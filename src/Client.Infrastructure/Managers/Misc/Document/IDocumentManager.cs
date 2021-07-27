using NoNonense.Application.Features.Documents.Commands.AddEdit;
using NoNonense.Application.Features.Documents.Queries.GetAll;
using NoNonense.Application.Requests.Documents;
using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;
using NoNonense.Application.Features.Documents.Queries.GetById;

namespace NoNonense.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}
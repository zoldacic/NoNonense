using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Features.DocumentTypes.Commands.AddEdit;
using NowWhat.Application.Features.DocumentTypes.Queries.GetAll;
using NowWhat.Shared.Wrapper;

namespace NowWhat.Client.Infrastructure.Managers.Misc.DocumentType
{
    public interface IDocumentTypeManager : IManager
    {
        Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
using NoNonense.Application.Features.Tags.Queries.GetAll;
using NoNonense.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoNonense.Application.Features.Tags.Commands.AddEdit;

namespace NoNonense.Client.Infrastructure.Managers.Catalog.Tag
{
    public interface ITagManager : IManager
    {
        Task<IResult<List<GetAllTagsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditTagCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
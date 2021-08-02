using NowWhat.Application.Features.Tags.Queries.GetAll;
using NowWhat.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Features.Tags.Commands.AddEdit;

namespace NowWhat.Client.Infrastructure.Managers.Catalog.Tag
{
    public interface ITagManager : IManager
    {
        Task<IResult<List<GetAllTagsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditTagCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
using NoNonense.Application.Features.Products.Commands.AddEdit;
using NoNonense.Application.Features.Products.Queries.GetAllPaged;
using NoNonense.Application.Requests.Catalog;
using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;

namespace NoNonense.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}
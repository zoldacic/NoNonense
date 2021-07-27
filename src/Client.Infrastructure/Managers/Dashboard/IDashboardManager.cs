using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;
using NoNonense.Application.Features.Dashboards.Queries.GetData;

namespace NoNonense.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}
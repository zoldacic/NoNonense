using NowWhat.Shared.Wrapper;
using System.Threading.Tasks;
using NowWhat.Application.Features.Dashboards.Queries.GetData;

namespace NowWhat.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}
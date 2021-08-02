using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Interfaces.Common;
using NowWhat.Application.Requests.Identity;
using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;

namespace NowWhat.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using NoNonense.Application.Interfaces.Common;
using NoNonense.Application.Requests.Identity;
using NoNonense.Application.Responses.Identity;
using NoNonense.Shared.Wrapper;

namespace NoNonense.Application.Interfaces.Services.Identity
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
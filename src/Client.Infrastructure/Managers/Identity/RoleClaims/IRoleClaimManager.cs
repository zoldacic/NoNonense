using System.Collections.Generic;
using System.Threading.Tasks;
using NoNonense.Application.Requests.Identity;
using NoNonense.Application.Responses.Identity;
using NoNonense.Shared.Wrapper;

namespace NoNonense.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}
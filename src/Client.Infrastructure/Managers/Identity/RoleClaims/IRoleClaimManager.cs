using System.Collections.Generic;
using System.Threading.Tasks;
using NowWhat.Application.Requests.Identity;
using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;

namespace NowWhat.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}
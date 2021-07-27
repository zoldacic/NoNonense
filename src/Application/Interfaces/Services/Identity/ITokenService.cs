using NoNonense.Application.Interfaces.Common;
using NoNonense.Application.Requests.Identity;
using NoNonense.Application.Responses.Identity;
using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;

namespace NoNonense.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}
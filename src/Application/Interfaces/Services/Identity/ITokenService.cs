using NowWhat.Application.Interfaces.Common;
using NowWhat.Application.Requests.Identity;
using NowWhat.Application.Responses.Identity;
using NowWhat.Shared.Wrapper;
using System.Threading.Tasks;

namespace NowWhat.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}
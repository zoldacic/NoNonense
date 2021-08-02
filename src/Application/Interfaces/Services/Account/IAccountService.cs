using NowWhat.Application.Interfaces.Common;
using NowWhat.Application.Requests.Identity;
using NowWhat.Shared.Wrapper;
using System.Threading.Tasks;

namespace NowWhat.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}
using NoNonense.Application.Interfaces.Common;
using NoNonense.Application.Requests.Identity;
using NoNonense.Shared.Wrapper;
using System.Threading.Tasks;

namespace NoNonense.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}
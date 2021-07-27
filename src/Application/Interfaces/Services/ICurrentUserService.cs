using NoNonense.Application.Interfaces.Common;

namespace NoNonense.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}
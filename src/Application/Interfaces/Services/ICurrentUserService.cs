using NowWhat.Application.Interfaces.Common;

namespace NowWhat.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}
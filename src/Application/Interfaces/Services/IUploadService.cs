using NowWhat.Application.Requests;

namespace NowWhat.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}
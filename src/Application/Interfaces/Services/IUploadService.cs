using NoNonense.Application.Requests;

namespace NoNonense.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}
using Microsoft.AspNetCore.Http;

namespace YogaOnline.Domain.Contracts.IServices
{
    public interface IFileStorage
    {
        Task<string> UploadFile(IFormFile file, string fileName = null);
    }
}

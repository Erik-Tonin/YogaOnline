using Microsoft.AspNetCore.Http;
using YogaOnline.Domain.Contracts.IServices;

namespace YogaOnline.Infra.Proxy
{
    public class FileStorage : IFileStorage
    {

        public async Task<string> UploadFile(IFormFile file, string fileName = null)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file), "Arquivo inválido.");

            var directory = "C:\\Users\\tonin\\Pictures\\Yoga";

            if (string.IsNullOrEmpty(fileName))
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(directory, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Retorna o caminho completo do arquivo
            return filePath;
        }
    }
}

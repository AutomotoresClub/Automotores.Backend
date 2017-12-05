using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend.Core
{
    public interface IUploadService
    {
         Task<string> UploadFile(IFormFile file, string bucketName);
    }
}
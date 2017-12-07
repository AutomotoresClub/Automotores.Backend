using System.Threading.Tasks;
using Automotores.Backend.Controllers.Resources;

namespace Automotores.Backend.Core
{
    public interface IIdentityService
    {
        Task<string> Register(UserResource userResource);
        
        Task<bool> ValidateUser(string email, string userName);
    }
}
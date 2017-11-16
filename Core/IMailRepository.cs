using System.Threading.Tasks;

namespace Automotores.Backend.Core
{
    public interface IMailRepository
    {
         Task<bool> SendEmail();
    }
}
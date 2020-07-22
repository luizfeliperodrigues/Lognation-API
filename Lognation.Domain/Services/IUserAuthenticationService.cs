using Lognation.Domain.Entities;
using System.Threading.Tasks;

namespace Lognation.Domain.Services
{
    public interface IUserAuthenticationService
    {
        Task SignUpAsync(User request);

        Task<Login> LoginAsync(string userNameOrEmail, string password);
    }
}

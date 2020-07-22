using Lognation.Domain.Common;
using Lognation.Domain.Entities;
using System.Threading.Tasks;

namespace Lognation.Domain.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
        Task<bool> AnyAsync(Login login);

        Task<Login> FindByLoginAsync(string userNameOrEmail);
    }
}

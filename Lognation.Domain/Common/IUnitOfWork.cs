using System.Threading.Tasks;

namespace Lognation.Domain.Common
{
    public interface IUnitOfWork
    {
        Task Commit();

        void Rollback();
    }
}

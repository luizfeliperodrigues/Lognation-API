using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lognation.Domain.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        void Delete(int id);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> criteria);

        Task<TEntity> FirstOrDefatultAsync(Expression<Func<TEntity, bool>> criteria);

        void Detach(TEntity entity);
    }
}

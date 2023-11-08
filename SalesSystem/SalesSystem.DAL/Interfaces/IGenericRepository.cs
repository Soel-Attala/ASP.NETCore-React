using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SalesSystem.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Edit(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);

    }
}

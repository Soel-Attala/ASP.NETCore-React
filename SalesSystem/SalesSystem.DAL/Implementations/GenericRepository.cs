using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSystem.DAL.DBContext;
using SalesSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesSystem.DAL.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SALESDBContext _dbContext;

        public GenericRepository(SALESDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}

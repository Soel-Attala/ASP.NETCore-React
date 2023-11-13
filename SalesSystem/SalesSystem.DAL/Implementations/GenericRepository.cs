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

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                TEntity entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch
            {
                throw;
            }

        }
        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }

        }
        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> queryEntity = filter == null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(filter);
            return queryEntity;
        }
    }
}

using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.Identity.Client;

namespace LinkDev.Talabat.Infrastructure.Persistence.GenericRepositories
{
    internal class GenericRepository<TEntity, TKey>(StoreContext _dbContext) : IGenericRepository<TEntity, TKey>
                                                                                 where TEntity : BaseAuditableEntity<TKey>
                                                                                 where TKey : IEquatable<TKey>
    {



        public async Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = true)
        {
            return WithTracking ?

                       await _dbContext.Set<TEntity>().ToListAsync() :
                       await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> spec, bool WithTracking = true)
        {
            //return await SpecificationsEvaluator<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), spec).ToListAsync();
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey Id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(Id);
        }
        public async Task<TEntity?> GetByIdWithSpecAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
            //return await SpecificationsEvaluator<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }

        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);



        #region Helpers Method
        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity , TKey> specs)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), specs);
        }

      
        #endregion

    }
}

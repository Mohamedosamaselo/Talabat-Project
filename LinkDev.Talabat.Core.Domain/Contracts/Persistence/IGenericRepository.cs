namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = true);
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> spec, bool WithTracking = true);


        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> GetByIdWithSpecAsync(ISpecifications<TEntity, TKey> spec);

        Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec);


        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

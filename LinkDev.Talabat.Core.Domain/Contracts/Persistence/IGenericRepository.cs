namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = true);
        
        Task<TEntity?> GetByIdAsync(TKey id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

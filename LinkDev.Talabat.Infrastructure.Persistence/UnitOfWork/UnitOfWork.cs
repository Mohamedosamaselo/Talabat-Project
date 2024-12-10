using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new ConcurrentDictionary<string, object>(); // ConcurrentDictionary Specifies with Asyncrouns Code 
        }

        public Task<int> CompleteAsync() => _dbContext.SaveChangesAsync();
        public ValueTask DisposeAsync() => _dbContext.DisposeAsync();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {

            //return new GenericRepository<TEntity, TKey>(_dbContext); // But We have an issue here [if we get the repo of the same entity more than once we have more than one instance of GenericRepo So We can create the object of Generic Repo of the entity then we save it in DataStructure Like Dictionary 3l4an lw 27tago mara tanya adelo the same object ]

            /// var TypeName = typeof(TEntity).Name; // Product[Key]
            /// 
            /// if (_repositories.ContainsKey(TypeName))// if Dictionary contains this Key , i will Return repo of this key  
            ///     return (IGenericRepository<TEntity, TKey>)_repositories[TypeName];// We make Explicit Casting as return => return object 
            /// 
            /// var repository = new GenericRepository<TEntity, TKey>(_dbContext); // Else Create new Repo
            /// _repositories.TryAdd(TypeName, repository); // Save Repo in Dictionary 3l4an lw talbo tany adelo nafs l object 
            /// 
            /// 
            /// return repository;


            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_dbContext));
            // GetOrAdd Method => Get the Current object[TEntity , TKey] if it exsists  , Add new object[TEntity , TKey] if it doesnot exsists 
       
        }
    }
}

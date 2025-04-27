using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using LinkDev.Talabat.Infrastructure.Persistence.GenericRepositories;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork(StoreContext dbContext) : IUnitOfWork
    {
        // make DataStructure to save object of Repos in it 
        // ConcurrentDictionary is more threadSafe 
        private readonly ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object> ();

        // implementation of UOfWork by lazy intialization 
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseAuditableEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            // return new GenericRepository<TEntity, TKey>(_dbContext); 
            // But We have an issue here [if we get the repo of the same entity more than once we have more than one instance of GenericRepo So We can create the object of Generic Repo of the entity then we save it in DataStructure Like Dictionary 3l4an lw 27tago mara tanya adelo the same object ]

            /// var TypeName = typeof(TEntity).Name; // Product[Key]
            /// 
            /// if (_repositories.ContainsKey(TypeName))// if Dictionary contains this Key , i will Return repo of this key  
            ///     return (IGenericRepository<TEntity, TKey>)_repositories[TypeName];// We make Explicit Casting as return => return object 
            /// 
            /// var repository = new GenericRepository<TEntity, TKey>(_dbContext); // Else Create new Repo
            /// _repositories.TryAdd(TypeName, repository); // Save Repo in Dictionary 3l4an lw talbo tany adelo nafs l object 
            /// 
            /// return repository;

            // GetOrAdd Method => Get the Current object[TEntity,TKey] if it exsists,Add new object[TEntity , TKey] if it doesnot exsists 
            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(dbContext));
            
        }

        public Task<int> CompleteAsync() => dbContext.SaveChangesAsync();
        public ValueTask DisposeAsync() => dbContext.DisposeAsync();

    }
}

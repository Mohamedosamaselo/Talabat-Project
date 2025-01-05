using System.Linq.Expressions;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
                                                    where TKey : IEquatable<TKey>
    {
        

        public Expression<Func<TEntity, bool>>? Criteria { get; set; }          // maybe Equalls Null When I Get All Entities 
        public List<Expression<Func<TEntity, object>>> Includes { get; set; }

        // Sorting the Products  
        public Expression<Func<TEntity ,object>>? OrderBy { get; set; }
        public Expression<Func<TEntity , object>>? OrderByDesc { get; set; }

        // Pagination 
        public int Skip { get; set; }
        public int Take { get; set; }
        bool IsPaginationEnabled { get; set; }
    };
}



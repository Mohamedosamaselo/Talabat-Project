using System.Linq.Expressions;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey>
                                                    where TEntity : BaseEntity<TKey>
                                                    where TKey : IEquatable<TKey>
    {
        
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }          // maybe Equalls Null When I Get All Entities 


        public List<Expression<Func<TEntity, object>>> Includes { get; set; }


    };
}



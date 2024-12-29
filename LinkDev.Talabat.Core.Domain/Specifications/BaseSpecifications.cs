using LinkDev.Talabat.Core.Domain.Contracts;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Core.Domain.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
                                                                                        where TEntity : BaseEntity<TKey>
                                                                                        where TKey : IEquatable<TKey>
    {
        // Automatic property Cimpiler will generate backingGround Field with Get; set; 
        public Expression<Func<TEntity ,bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new () ;




        // this ParameterLess constructor will use to create object from baseSpecification object that used to get All Entities 
        public BaseSpecifications()
        {
            //Criteria = null;
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }
        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);      // p => p.Id.equals(1); 
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }
    }
}

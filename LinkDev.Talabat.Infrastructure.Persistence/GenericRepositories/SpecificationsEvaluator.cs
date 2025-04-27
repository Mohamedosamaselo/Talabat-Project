using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastructure.Persistence.GenericRepositories
{
    public static class SpecificationsEvaluator<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // public static classMember Method that Return Query  // take Dbset<TEnitty> , Specification Oject 
        public static IQueryable<TEntity> GetQuery( IQueryable<TEntity> DbSet, ISpecifications<TEntity, TKey> Spec )
        {
            var Query = DbSet;                       //  _dbContext.Set<TEntity>()

            if (Spec.Criteria is not null)           // p => p.Id.Equals(1);
                Query = Query.Where(Spec.Criteria);  // query =  _dbContext.Set<TEntity>().Where(p => p.Id.Equals(1))

            if (Spec.OrderByDesc is not null)
                Query = Query.OrderByDescending(Spec.OrderByDesc);

            else if (Spec.OrderBy is not null)
                Query = Query.OrderBy(Spec.OrderBy);

            if (Spec.IsPaginationEnabled)            // Apply Pagination 
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);

            // query =  _dbContext.Set<TEntity>().Where(p => p.Id.Equals(1))
            /// Include Expressions
            /// 1. p => p.Brand
            /// 2. P => P.Category 

            Query = Spec.IncludeExpressions.Aggregate(Query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            /// _dbContext.Set<TEntity>().Where(p => p.Id.Equals(1)).include( p => p.Brand );
            /// _dbContext.Set<TEntity>().Where(P => P.Id.Equals()).include(P => P.Brand).include( p => p.category ) ; 

            return Query;

        }
    }
}

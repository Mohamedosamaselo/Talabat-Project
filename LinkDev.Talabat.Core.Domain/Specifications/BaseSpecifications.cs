using LinkDev.Talabat.Core.Domain.Contracts;
using System.Linq.Expressions;

namespace LinkDev.Talabat.Core.Domain.Specifications
{
    public abstract class   BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
                             where TEntity : BaseEntity<TKey>
                             where TKey : IEquatable<TKey>
    {
        // Automatic property Compiler will generate backingField with Get; set; 
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; } = new List<Expression<Func<TEntity, object>>> ();
        
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; } = null;
       
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }


        // Methods

        protected BaseSpecifications()
        {
            
        }

        // this constructor will use to create object from baseSpecification object that used to get All Entities 
        protected BaseSpecifications(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }

        // this constructor will use to create object from baseSpecification object that Used To Get Spescific Entity based on id 
        protected BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);      // p => p.Id.equals(1); 
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }
        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>> orderByExpressionDesc)
        {
            OrderBy = orderByExpressionDesc;
        }
        private protected virtual void AddIncludes()
        {
        }
        private protected void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}


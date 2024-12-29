using LinkDev.Talabat.Core.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Specifications.ProductSpecifications
{
    public class ProductWithCategoryandBrandSpecifications :BaseSpecifications<Product , int> 
    {
        // the Specification object Created via this Constructor  is used for building the query that will Get all products .
        public ProductWithCategoryandBrandSpecifications() : base()
        {
            AddIncludes();
        }

      

        // the Specification Object that created via this Constructor is used for building the query that will get Specific Product by Id .
        public ProductWithCategoryandBrandSpecifications(int id) : base(id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(p => p.Brand!);
            Includes.Add(p => p.Category!);
        }
    }
}

using LinkDev.Talabat.Core.Domain.Entities.Products;


namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithCategoryandBrandSpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithCategoryandBrandSpecifications(string? Sort, int? brandId, int? categoryId, int pageSize, int pageIndex , string? search)
                            : base(
                                    p =>
                                        (string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
                                                        &&
                                        (!brandId.HasValue || p.BrandId == brandId)
                                                        &&
                                        (!categoryId.HasValue || p.CategoryId == categoryId)
                                  )
        {
            AddIncludes();


            switch (Sort)
            {
                case "nameDesc":
                    AddOrderByDesc(p => p.Name);
                    break;

                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;

                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;

                default:
                    AddOrderBy(p => p.Name);
                    break;
            }


            ApplyPagination(pageSize * (pageIndex - 1), pageSize);    // totalProducts = 18 ~ 20
                                                                      // pageSize  = 5
                                                                      // pageIndex = 3   => 0 1 2 3 
        }

        // the Specification Object that created via this Constructor is used for building the query that will get Specific Product by Id .
        public ProductWithCategoryandBrandSpecifications(int id) : base(id)
        {
            AddIncludes();
        }

        private protected override void AddIncludes()
        {
            base.AddIncludes();

            Includes.Add(p => p.Brand!);
            Includes.Add(p => p.Category!);

        }

    }
}

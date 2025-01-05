using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using LinkDev.Talabat.Core.Domain.Specifications.Products;

namespace LinkDev.Talabat.Core.Application.Services.Products
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {


        private IEnumerable<ProductToReturnDto> productsToReturn;

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams specParams)
        {
            var spec = new ProductWithCategoryandBrandSpecifications(specParams.Sort, specParams.BrandId, specParams.CategoryId, specParams.PageSize, specParams.PageIndex ,specParams.Search);

            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);

            var productToReturns = mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            var countSpec = new ProductWithFilterationForCountSpecifications(specParams.BrandId, specParams.CategoryId , specParams.Search);

            var count = await unitOfWork.GetRepository<Product, int>().GetCountAsync(countSpec);

            return new Pagination<ProductToReturnDto>(specParams.PageIndex , specParams.PageSize , count ) { Data = productToReturns};
        }

        public async Task<ProductToReturnDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithCategoryandBrandSpecifications(id);

            var product = await unitOfWork.GetRepository<Product, int>().GetByIdWithSpecAsync(spec);

            var productToReturn = mapper.Map<ProductToReturnDto>(product);

            return productToReturn;
        }



        public async Task<IEnumerable<BrandDto>> GetBrandAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsToReturn = mapper.Map<IEnumerable<BrandDto>>(brands);

            return brandsToReturn;

        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesToReturn;

        }


    }
}

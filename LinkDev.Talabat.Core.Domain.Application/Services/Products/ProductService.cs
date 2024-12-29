using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using LinkDev.Talabat.Core.Domain.Specifications.ProductSpecifications;

namespace LinkDev.Talabat.Core.Application.Services.Products
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
        {
            var spec = new ProductWithCategoryandBrandSpecifications();

            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);

            var productsToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            return productsToReturn;
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
            var categories = await unitOfWork.GetRepository<ProductCategory , int>().GetAllAsync();

            var categoriesToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesToReturn;
    
        }
    }
}

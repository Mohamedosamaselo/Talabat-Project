using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
    public  interface IProductService
    {
        Task<IEnumerable<ProductToReturnDto>> GetProductsAsync();
    
        Task<ProductToReturnDto> GetProductByIdAsync(int id);

        Task<IEnumerable<BrandDto>> GetBrandAsync();

        Task<IEnumerable<CategoryDto>> GetCategoryAsync();


    }
}

using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Product
{
    public  interface IProductService
    {
        Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams specParams);
    
        Task<ProductToReturnDto> GetProductByIdAsync(int id);

        Task<IEnumerable<BrandDto>> GetBrandAsync();

        Task<IEnumerable<CategoryDto>> GetCategoryAsync();


    }
}

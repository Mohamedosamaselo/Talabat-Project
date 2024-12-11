using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

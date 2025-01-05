using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Api.Controllers.Errors;
using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Products
{
    public class ProductController(IServiceManager serviceManager) : BaseApiController
    {
        // Get Products EndPoint
        [HttpGet] // Get : api/product
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {

            var products = await serviceManager.ProductService.GetProductsAsync(specParams);
            return Ok(products);
        }

        [HttpGet("{id:int}")] // Get : api/product/2
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(new ApiResponse(404, $"The Product With Id:{id} is not Found "));

            return Ok(product);
        }


        [HttpGet("brands")] // Get : api/Product/brand
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetBrandAsync();
            return Ok(brands);
        }

        [HttpGet("categories")] // Get : api/products/categories
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetCategoryAsync();
            return Ok(categories);
        }


    }
}

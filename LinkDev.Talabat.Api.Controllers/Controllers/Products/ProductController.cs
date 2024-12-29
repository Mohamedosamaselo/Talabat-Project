using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Products
{
    public class ProductController(IServiceManager serviceManager) : BaseApiController
    {
        // Get PRoducts EndPoint
        [HttpGet] // Get : api/product
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var products = await serviceManager.ProductService.GetProductsAsync();
            return Ok(products);
        }


        [HttpGet("{id:int}")] // Get : api/product/2
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product =await   serviceManager.ProductService.GetProductByIdAsync(id);

            
            if (product == null)
                return NotFound(new { StatusCode = 404, Message = "Not Found" });


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

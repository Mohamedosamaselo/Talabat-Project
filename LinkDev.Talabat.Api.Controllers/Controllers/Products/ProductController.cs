using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Products
{
    public class ProductController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet] // Get : api/products
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var products = await serviceManager.ProductService.GetProductsAsync();
            return Ok(products);

        }
    }
}

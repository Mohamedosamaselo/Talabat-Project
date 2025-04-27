using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Basket
{

    public class BasketController(IServiceManager serviceManager) :BaseApiController
    {
        [HttpGet] // Get : /api/Basket?id = ""
        public async Task <ActionResult<CustomerBasketDto>> GetBasket(string id)
        {
            var basket = await serviceManager.BasketService.GetCustomerBasket(id);
            return Ok(basket);
        }

        [HttpPost] // Post : api/Basket

        public async Task <ActionResult<CustomerBasketDto>> UpdateBasket (CustomerBasketDto basketDto)
        {
            var updatedBasket = await serviceManager.BasketService.UpdateCustomerBasketAsync(basketDto);
            return Ok(updatedBasket);
        }


        [HttpDelete] //Delete  : api/Basket?id=""
        public async Task DeleteBasket(string id)
        {
            await serviceManager.BasketService.DeleteCustomerBasket(id);
        }

    }
}

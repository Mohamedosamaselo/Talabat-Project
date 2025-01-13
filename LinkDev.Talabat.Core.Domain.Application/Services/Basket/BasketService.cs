using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services.Basket
{
    public class BasketService(IBasketRepository basketrepository, IMapper mapper) : IBasketService
    {
        public async Task<CustomerBasketDto> GetCustomerBasket(string basketId)
        {
            var basket = basketrepository.GetBasketAsync(basketId);

            if (basket is null)
                return new CustomerBasketDto() { Id = basketId };

            return mapper.Map<CustomerBasketDto>(basket);
        }

        public async Task<CustomerBasketDto?> UpdateCustomerBasketAsync(CustomerBasketDto basketDto)
        {
            var basket = mapper.Map<CustomerBasket>(basketDto);

            var updatedBasket = await basketrepository.UpdateBasketAsync(basket);

            if (updatedBasket is null)
                throw new Exception(); // lmafroud throw exception here  , it will be updated 
            return basketDto;

        }

        public async Task DeleteCustomerBasket(string BasketId)
        {
            var isDeleted = await basketrepository.DeleteBasketAsync(BasketId);

            if(!isDeleted)
                throw new Exception();// it will be Updated


        }


    }
}

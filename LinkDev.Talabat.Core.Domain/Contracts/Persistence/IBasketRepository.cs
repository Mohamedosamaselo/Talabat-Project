﻿using LinkDev.Talabat.Core.Domain.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string id);

        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string id);

    }
}

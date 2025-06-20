﻿using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Application.Services.Basket;
using LinkDev.Talabat.Core.Application.Services.Products;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;

namespace LinkDev.Talabat.Core.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository )
        {
            _unitOfWork = unitOfWork;
            
            _mapper = mapper;
            
            // lazy initialization 
            _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper)); 
        
            _basketService = new Lazy<IBasketService>(() => new BasketService(basketRepository, mapper));
        
        }

        public IProductService ProductService => _productService.Value;
        public IBasketService BasketService => _basketService.Value;

    }
}

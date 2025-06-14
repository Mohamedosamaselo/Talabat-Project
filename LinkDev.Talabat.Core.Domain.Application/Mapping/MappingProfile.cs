﻿using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Domain.Entities.Basket;
using LinkDev.Talabat.Core.Domain.Entities.Products;

namespace LinkDev.Talabat.Core.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        // parameterless Constructor 
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name)) // Destenation Member  , Action<IMemeberConfiguration> => mapfrom (srcMemberPath)
                .ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name))
                //.ForMember(d => d.PictureUrl , o => o.MapFrom(s => $"{"https://localhost:7163"}{s.PictureUrl}"))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());


            CreateMap<ProductBrand, BrandDto>();// map from ProductBrand to BrandDto 

            CreateMap<ProductCategory, CategoryDto>();

            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();

            CreateMap <BasketItem, BasketItemDto>().ReverseMap();    


        }
    }
}

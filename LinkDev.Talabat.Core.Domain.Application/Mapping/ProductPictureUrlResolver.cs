using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Core.Application.Mapping
{
    internal class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductToReturnDto, String?>
    {
        public string? Resolve(Product source, ProductToReturnDto destination, string? destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["URLS:ApiBaseUrl"]}/{source.PictureUrl}";
         

            return string.Empty ; 

        }
    }
}

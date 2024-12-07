using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Products
{
    internal class CategoryConfigurations : BaseEntityConfiguration<ProductCategory , int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(C => C.Name).IsRequired();
        }

    }
}

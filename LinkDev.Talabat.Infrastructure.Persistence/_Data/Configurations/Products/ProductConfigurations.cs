using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Products
{
    internal class ProductConfigurations : BaseEntityConfiguration<Product, int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(9,2)");

            //RelationShips 
            builder.HasOne(P => P.Brand)
                .WithMany()// Brand With Many Product 
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(P => P.Category)
             .WithMany()// Category With Many Product 
             .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.SetNull);




        }

    }
}

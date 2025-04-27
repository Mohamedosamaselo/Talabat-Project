using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Common
{
    public class BaseAuditableEntityConfiguration<TEntity, TKey> : BaseEntityConfiguration<TEntity, TKey>
                                                                     where TEntity : BaseAuditableEntity<TKey>
                                                                     where TKey : IEquatable<TKey>
    {

        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.CreatedBy)
                .IsRequired();

            builder.Property(E => E.CreatedOn)
                .IsRequired();

            builder.Property(E => E.LastModifiedBy)
                   .IsRequired();

            builder.Property(E => E.LastModifiedOn)
                   .IsRequired();

        }
    }
}

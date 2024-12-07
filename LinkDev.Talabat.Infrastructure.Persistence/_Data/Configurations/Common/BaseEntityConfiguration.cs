﻿using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Configurations.Common
{
    public class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {



            builder.Property(E => E.Id)
               .ValueGeneratedOnAdd();// if the pk of type Numeric Bydefault startby 1 , IncrementBy 1 || if the Pk of type Guid , every time it generate New Guid  

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
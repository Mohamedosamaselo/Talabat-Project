﻿
namespace LinkDev.Talabat.Core.Domain.Entities.Product
{
    public class ProductCategory : BaseEntity<int> 
    {
        public required string Name { get; set; }


        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
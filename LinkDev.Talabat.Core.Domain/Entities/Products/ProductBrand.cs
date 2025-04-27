
namespace LinkDev.Talabat.Core.Domain.Entities.Products
{
    public class ProductBrand : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }


        // Navigational Property [Many]
        // public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); // Reference Looping Issue

    }
}

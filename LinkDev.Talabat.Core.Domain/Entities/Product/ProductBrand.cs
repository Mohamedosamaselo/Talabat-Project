namespace LinkDev.Talabat.Core.Domain.Entities.Product
{
    public class ProductBrand
    {
        public required string Name { get; set; }



        // Navigational Property [Many]
        // public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); // Reference Looping Issue

    }
}

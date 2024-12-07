
namespace LinkDev.Talabat.Core.Domain.Entities.Product
{
    public class Product : BaseEntity<int>
    {

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string PictureUrl { get; set; }
        public required decimal Price { get; set; }



        // RelationShip between  ProductBrand[one] : Product[many] 
        public int? BrandId { get; set; }                // ForeignKey ProductBrands Entity .
        public virtual ProductBrand? Brand { get; set; } // Navigational Property [one] Product[one]:ProductBrands[Many]
                                                         // Nullable as When we delete Brand , We Set Product of this brand by null ; 
                                                         // All Navigational Property Are Virtual As We Implement LazyLoading Mode


        // RelationShip Between ProductCategory[one] : Product[Many]
        public int? CategoryId { get; set; }                   // ForeignKey ProductCategory Entity . 
        public virtual ProductCategory? Category { get; set; }//Navigational Property [one] product[one]:Category[Many]


    }
}

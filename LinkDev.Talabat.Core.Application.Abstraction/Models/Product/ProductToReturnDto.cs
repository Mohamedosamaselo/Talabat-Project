namespace LinkDev.Talabat.Core.Application.Abstraction.Models.Product
{
    public class ProductToReturnDto
    {

        public  int Id { get; set; } // P.K
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string PictureUrl { get; set; }
        public required decimal Price { get; set; }
        public int? BrandId { get; set; }                // ForeignKey ProductBrands Entity .
        public  string? Brand { get; set; } // Navigational Property [one] Product[one]:ProductBrands[Many]
                                                         // Nullable as When we delete Brand , We Set Product of this brand by null ; 
                                                         // All Navigational Property Are Virtual As We Implement LazyLoading Mode

        // RelationShip Between ProductCategory[one] : Product[Many]
        public int? CategoryId { get; set; }                   // ForeignKey ProductCategory Entity . 
        public  string? Category { get; set; }//Navigational Property [one] product[one]:Category[Many]

    }
}

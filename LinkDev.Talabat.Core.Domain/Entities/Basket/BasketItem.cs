using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Entities.Basket
{
    public class BasketItem : BaseEntity<int>
    {
        public required string?  ProductName { get; set; }
        public string?  PictureUrl { get; set; }
        public decimal Price { get; set; } // price Of Product as aItem inside Basket 
        public int Quantity { get; set; }
        public string?  Brand { get; set; }
        public string?  Category { get; set; }


    }
}

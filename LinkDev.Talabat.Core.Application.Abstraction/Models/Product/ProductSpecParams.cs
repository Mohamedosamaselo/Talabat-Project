using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Abstraction.Models.Product
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;

        private string? search;

        private int pageSize = 5;// default pageSize is 5 products . 
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;   

        public int PageSize 
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public string? Search
        {
            get { return search; }
            set { search = value?.ToUpper(); }
        }

    }
}

using LinkDev.Talabat.Core.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<Product , int> ProductRepository { get;  }
        public IGenericRepository<ProductBrand , int> ProductBrandRepository { get;  }
        public IGenericRepository<ProductCategory , int> ProductCategoryRepository { get;  }


        Task<int> CompleteAsync()

    }
}

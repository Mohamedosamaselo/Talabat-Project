using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence._Data;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext dbContext;
        private readonly Lazy<GenericRepository<Product, int>> _ProductRepo;
        private readonly Lazy<GenericRepository<ProductBrand, int>> _ProductBrandsRepo;
        private readonly Lazy<GenericRepository<ProductCategory, int>> _ProductCatgeoriesRepo;

        public UnitOfWork(StoreContext dbContext)
        {
            this.dbContext = dbContext;
            _ProductRepo = new Lazy<GenericRepository<Product, int>>(()                   => new GenericRepository<Product, int>(dbContext));
            _ProductBrandsRepo = new Lazy<GenericRepository<ProductBrand, int>>(()        => new GenericRepository<ProductBrand, int>(dbContext));
            _ProductCatgeoriesRepo = new Lazy<GenericRepository<ProductCategory, int>>(() => new GenericRepository<ProductCategory, int>(dbContext));
        }
        public IGenericRepository<Product, int> ProductRepository => _ProductRepo.Value;
        public IGenericRepository<ProductBrand, int> ProductBrandRepository => _ProductBrandsRepo.Value;
        public IGenericRepository<ProductCategory, int> ProductCategoryRepository => _ProductCatgeoriesRepo.Value;

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}

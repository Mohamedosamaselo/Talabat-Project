
using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Entities.Products;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

     

        public StoreContext(DbContextOptions<StoreContext> Options) : base(Options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Get Current Assembly Persistance & Get All Classes that inherit from IEntityTypeConfigurations interface

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);// Get persistance layer assembly reference by AssemblyInformation Class [Class that get All Assembly References from it ]
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}

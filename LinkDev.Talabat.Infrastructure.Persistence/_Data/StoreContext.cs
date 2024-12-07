
using LinkDev.Talabat.Core.Domain.Entities.Product;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data
{
    public class StoreContext : DbContext
    {
     

        public StoreContext(DbContextOptions<StoreContext> Options) : base(Options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Get Current Assembly Persistance & Get All Classes that inherit from IEntityTypeConfigurations

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);// Get persistance layer assembly reference by AssemblyInformation Class [Class that get All Assembly References from it ]
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

    }
}

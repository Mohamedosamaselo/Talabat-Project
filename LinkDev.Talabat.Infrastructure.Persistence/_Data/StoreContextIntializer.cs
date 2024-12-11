using LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers;
using LinkDev.Talabat.Core.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data
{
    internal class StoreContextIntializer(StoreContext _dbContext) : IStoreContextIntializer
    {


        public async Task InitializeAsync() // Update Databse 
        {
            var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();// 1. Get All Pending Migrations

            if (PendingMigrations.Any())                                                  
                await _dbContext.Database.MigrateAsync();                                 // 2. Update Database  
        }



        public async Task SeedAsync()
        {

            if (!_dbContext.Brands.Any())//if table brands doesnot contain data
            {
                var brandsData = await File.ReadAllTextAsync(@"../LinkDev.Talabat.Infrastructure.Persistence/_Data/DataSeeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);// deserialize from json as string to list<ProductBrands>


                if (brands?.Count > 0) //[ brands is not null && brands.count > 0 ] check if the brands not null & count more than zero 
                {
                    ///foreach (var brand in brands)
                    ///{
                    ///    await _dbContext.Brands.AddAsync(brand);// Add brand to brand table
                    ///}
                    await _dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await _dbContext.SaveChangesAsync();//saveChanges after change the state of all brands not with each brand
                }
            }

            if (!_dbContext.Categories.Any())//if table brands doesnot contain data
            {
                var categoriesData = await File.ReadAllTextAsync(@"../LinkDev.Talabat.Infrastructure.Persistence/_Data/DataSeeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);// deserialize from json as string to list<ProductCategories>


                if (categories?.Count > 0) //[ categories is not null && categories.count > 0 ] check if the brands not null & count more than zero 
                {
                    ///foreach (var category in categories)
                    ///{
                    ///    await _dbContext.Brands.AddAsync(category);// Add category to category table
                    ///}
                    await _dbContext.Set<ProductCategory>().AddRangeAsync(categories);
                    await _dbContext.SaveChangesAsync();//saveChanges after change the state of all brands not with each brand
                }
            }

            if (!_dbContext.Products.Any())//if table Products doesnot contain data
            {
                var ProductsData = await File.ReadAllTextAsync(@"../LinkDev.Talabat.Infrastructure.Persistence/_Data/DataSeeding/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);// deserialize from json as string to list<ProductBrands>


                if (products?.Count > 0)
                {
                    await _dbContext.Set<Product>().AddRangeAsync(products);
                    await _dbContext.SaveChangesAsync();//saveChanges after change the state of all brands not with each brand
                }
            }
        
        
        }
    }
}

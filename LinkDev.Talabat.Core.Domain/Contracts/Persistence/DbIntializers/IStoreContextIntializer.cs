namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers
{
    public interface IStoreContextIntializer
    {
        Task UpdateDatabaseAsync(); //To Update Database 

        Task SeedAsync(); // Seed
    
    }

}

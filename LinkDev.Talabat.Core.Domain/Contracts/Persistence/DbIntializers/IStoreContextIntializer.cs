namespace LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers
{
    public interface IStoreContextIntializer
    {
        Task InitializeAsync();
        Task SeedAsync();
    }

}

using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Interceptors
{
    internal class CustomSaveChangesInterceptor(ILoggedInUserService loggedInUserService) : SaveChangesInterceptor
    {


        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            UpdateEntities(eventData.Context);

            return base.SavedChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }


        private void UpdateEntities(DbContext? dbContext)
        {
            if (dbContext is null)
                return;
            
            foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>()
                .Where(Entity => Entity.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow; // Note that in Create , Update Anu Entity that inherit From BaseAduitableEntity it Must be Authenticated User 
                    entry.Entity.CreatedBy = loggedInUserService.UserId!;
                }
                entry.Entity.LastModifiedOn = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = loggedInUserService.UserId!;
            }
        }
    }
}

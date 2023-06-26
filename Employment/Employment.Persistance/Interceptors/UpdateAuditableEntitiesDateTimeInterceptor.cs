using Employment.Domain.BasesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Interceptors
{
    public class UpdateAuditableEntitiesDateTimeInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if(dbContext is null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }
            IEnumerable<EntityEntry<IAuditable>> auditableEntries = dbContext.ChangeTracker.Entries<IAuditable>().Where(en => en.State != EntityState.Unchanged);
            foreach (var entityEntry in auditableEntries)
            {
                if(entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(ee => ee.DateTimeAdded).CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(ee => ee.DateTimeModified).CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Deleted)
                {
                    entityEntry.Property(ee => ee.DateTimeDeleted).CurrentValue = DateTime.Now;
                }
            }
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}

using Employment.Common.Enums;
using Employment.Domain;
using Employment.Domain.BasesModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Employment.Persistance.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, string, 
                                                  IdentityUserClaim<string>,
                                                  UserRole,
                                                  IdentityUserLogin<string>,
                                                  IdentityRoleClaim<string>,
                                                  IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<EducationHistory> EducationHistories { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Inductries { get; set; }
        public DbSet<JobExperience> JobExperience { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<JobSeniorityLevel> JobSeniorityLevels { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            LogAndSaveChanges();
            return 1;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await LogAndSaveChangesAsync();
            return 1;
        }




        #region Private Method
        private void ChangeEntityDateTimes()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateTimeModified = DateTime.Now;
                }
                else if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateTimeAdded = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.DateTimeDeleted = DateTime.Now;
                }
            }
        }
        private async Task BaseSaveChangesAsync()
        {
            ChangeEntityDateTimes();
            await base.SaveChangesAsync();
        }
        private void BaseSaveChanges()
        {
            ChangeEntityDateTimes();
            base.SaveChanges();
        }
        private async Task LogAndSaveChangesAsync()
        {
            this.ChangeTracker.DetectChanges();
            var trackedEntities = this.ChangeTracker.Entries().Where(en => en.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged).ToList();
            var historiesList = LogChanges(trackedEntities);
            await BaseSaveChangesAsync();
            foreach (var entityLogs in historiesList)
            {
                await this.Histories.AddRangeAsync(entityLogs.Histories);
                foreach (var history in entityLogs.Histories)
                {
                    history.RecordId = entityLogs.entity.Entity.GetType().GetProperty("Id").GetValue(entityLogs.entity.Entity).ToString();
                }
            }
            await BaseSaveChangesAsync();
            await Task.CompletedTask;
        }

        private void LogAndSaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var trackedEntities = this.ChangeTracker.Entries().Where(en => en.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged).ToList();
            var historiesList = LogChanges(trackedEntities);
            base.SaveChanges();
            foreach (var entityLogs in historiesList)
            {
                this.Histories.AddRange(entityLogs.Histories);
                foreach (var history in entityLogs.Histories)
                {
                    history.RecordId = entityLogs.entity.Entity.GetType().GetProperty("Id").GetValue(entityLogs.entity.Entity).ToString();
                }
            }
            base.SaveChanges();
        }

        private List<(List<History> Histories, EntityEntry entity)> LogChanges(List<EntityEntry> entityEntries)
        {
            var historiesList = new List<(List<History>, EntityEntry)>();
            foreach (var entry in entityEntries)
            {
                var entityName = entry.Metadata.Name.Split('.').Last();
                // --- if entity name is defined in the exceptions enumeration, it will not be loged --- //
                if (Enum.IsDefined(typeof(IgnoredModelFromHIstory), entityName))
                {
                    continue;
                }
                if (entry == null) continue;
                var histories = GetChangesHistoryList(entry, entry.State);
                historiesList.Add((histories, entry));
            }
            return historiesList;
        }

        private List<History> GetChangesHistoryList(EntityEntry entity, EntityState state)
        {
            var historyList = new List<History>();
            var entityProperties = entity.Properties;
            var entityName = GetDomainDisplayName(entity);
            string recordId = null;
            foreach (var property in entityProperties)
            {
                var propertyName = property.Metadata.Name;
                var propertyDisplayName = GetPropertyDisplayName(entity, propertyName);
                if (propertyName.ToString().ToLower() == "id")
                {
                    recordId = property.CurrentValue.ToString();
                    continue;
                }
                GetValues(property, state, out string oldValue, out string currentValue);
                if (state == EntityState.Modified && oldValue == currentValue)
                {
                    continue;
                }
                historyList.Add(new History()
                {
                    Id = Guid.NewGuid().ToString(),
                    PreviousValue = oldValue,
                    NextValue = currentValue,
                    ChangeDate = DateTime.Now,
                    FieldName = propertyDisplayName,
                    TableName = entityName,
                    ChangeState = state.ToString(),
                    RecordId = recordId
                });
            }
            return historyList;
        }

        private void GetValues(PropertyEntry property, EntityState state, out string oldValue, out string currentValue)
        {
            oldValue = null;
            currentValue = null;
            switch (state)
            {
                case EntityState.Deleted:
                    oldValue = property.OriginalValue == null ? null : property.OriginalValue.ToString();
                    break;
                case EntityState.Modified:
                    oldValue = property.OriginalValue == null ? null : property.OriginalValue.ToString();
                    currentValue = property.CurrentValue == null ? null : property.CurrentValue.ToString();
                    break;
                case EntityState.Added:
                    currentValue = property.CurrentValue == null ? null : property.CurrentValue.ToString();
                    break;
            }
        }

        private string GetPropertyDisplayName(EntityEntry entity, string propertyName)
        {
            var properties = entity.Entity.GetType().GetProperties();
            var propery = properties.Where(prop => prop.Name.ToLower() == propertyName.ToLower()).FirstOrDefault();
            var displayName = propery.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;
            if (displayName != null)
            {
                return displayName.DisplayName;
            }
            return propertyName;
        }

        private string GetDomainDisplayName(EntityEntry entity)
        {
            var displayName = entity.Entity.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                              .FirstOrDefault()
                                              as DisplayNameAttribute;
            if (displayName != null)
            {
                return displayName.DisplayName;
            }
            return entity.Metadata.Name.Split('.').Last();
        }

        #endregion

    }
}

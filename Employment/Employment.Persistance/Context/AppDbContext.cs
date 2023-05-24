using Employment.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

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
        public DbSet<Resume> Rsumes { get; set; }
        public DbSet<EducationHistory> EducationHistories { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Major> Majors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<DomainBaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<DomainBaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChangesAsync();
        }


    }
}

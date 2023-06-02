using Employment.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

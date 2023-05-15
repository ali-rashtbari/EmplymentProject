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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

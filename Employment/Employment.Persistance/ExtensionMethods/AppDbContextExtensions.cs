using Employment.Common.Constants;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.ExtensionMethods
{
    public static class AppDbContextExtensions
    {
        public static void Seed(this AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if(dbContext.Roles.Any())
            {
                return;
            }

            var roles = new List<Role>()
            {
                new Role()
                {
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id = Guid.NewGuid().ToString(),
                    Name = RoleNames.Admin,
                    NormalizedName = RoleNames.Admin.ToUpper()
                },
                new Role()
                {
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id = Guid.NewGuid().ToString(),
                    Name = RoleNames.User,
                    NormalizedName = RoleNames.User.ToUpper()   
                }
            };

            using var transaction = dbContext.Database.BeginTransaction();

            dbContext.Roles.AddRange(roles);
            dbContext.SaveChanges();

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Ali",
                LastName = "Rashtbari",
                UserName = "admin@employment.com",
                Email = "admin@employment.com",
                NormalizedUserName = "admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Mobile = "09917586411"
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123456789@Ali");

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userRole = new UserRole()
            {
                RoleId = dbContext.Roles.AsNoTracking().First(r => r.NormalizedName == RoleNames.Admin.ToUpper()).Id,
                UserId = dbContext.Users.First().Id
            };

            dbContext.UserRoles.Add(userRole);
            dbContext.SaveChanges();

            transaction.Commit();
        }
    }
}

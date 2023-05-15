using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = @"Server = (localdb)\MSSQLLocalDB; DataBase = Employment; Integrated Security = true; MultipleActiveResultSets = true;";

            dbContextOptionsBuilder.UseSqlServer(connectionString, builder =>
            {

            });

            return new AppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}

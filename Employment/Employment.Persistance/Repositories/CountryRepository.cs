using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public bool IsExists(string name)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.Name.Trim().ToLower() == name.Trim().ToLower()) != null;
        }
    }
}

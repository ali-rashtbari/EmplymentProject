using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly AppDbContext _appDbContext;
        public CityRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;   
        }

        public bool IsExists(string name)
        {
            return _appDbContext.Cities.Any(c => c.Name.ToLower() == name.ToLower());
        }

        public bool IsInCountry(int cityId, int countryId)
        {
            return _appDbContext.Countries.Include(c => c.Provinces)
                                          .ThenInclude(p => p.Cities)
                                          .FirstOrDefault(c => c.Id == countryId)
                                          .Provinces.SelectMany(p => p.Cities)
                                          .Any(c => c.Id == cityId);
        }
    }
}

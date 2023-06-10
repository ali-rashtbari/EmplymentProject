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
    public class IndustryRepository : GenericRepository<Industry>, IIndustryRepository
    {
        private readonly AppDbContext _appDbContext;
        public IndustryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool IsExists(string name)
        {
            return _appDbContext.Inductries.Any(i => i.Name.ToLower() == name.ToLower());
        }
    }
}

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
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        private readonly AppDbContext _appDbContext;
        public MajorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public bool IsExistsWithName(string displayName)
        {
            return _appDbContext.Majors.FirstOrDefault(m => m.DisplayName.ToLower() == displayName) != null;
        }
    }
}

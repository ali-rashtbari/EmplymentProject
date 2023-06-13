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
    public class JobExperienceRepository : GenericRepository<JobExperience>, IJobExperienceRepository
    {
        private readonly AppDbContext _dbContext;
        public JobExperienceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _dbContext = appDbContext;
        }

    }
}

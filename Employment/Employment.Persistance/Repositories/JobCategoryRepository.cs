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
    public class JobCategoryRepository : GenericRepository<JobCategory>, IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public JobCategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool IsExists(string name)
        {
            return _appDbContext.JobCategories.Any(jc => jc.Name.ToLower() == name.ToLower()) ;
        }
    }
}

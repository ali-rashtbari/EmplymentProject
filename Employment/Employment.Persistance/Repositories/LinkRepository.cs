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
    public class LinkRepository : GenericRepository<Link>, ILinkRepository
    {
        private readonly AppDbContext _dbContext;

        public LinkRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _dbContext = appDbContext;
        }

        public void AddToResume(Link link, Resume resume)
        {
            resume.Links.Add(link);
            _dbContext.SaveChanges();
        }

        public async Task AddToResumeAsync(int linkId, int resumeId)
        {
            var resume = await _dbContext.Resumes.Include(r => r.Links).SingleOrDefaultAsync(r => r.Id == resumeId);
            var link = await _dbContext.Links.FindAsync(linkId);
            resume.Links.Add(link);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}

using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employment.Persistance.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly AppDbContext _dbContext;

        public ProfileRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CheckCompleteness(Profile profile)
        {
            var resume = _dbContext.Entry(profile).Reference(p => p.Resume);
            if(!resume.IsLoaded)
            {
                await resume.LoadAsync();
            }

            var isCompleted = profile.Gender.HasValue &&
                              profile.Address.Any() &&
                              profile.Biography.Any() &&
                              profile.BirthDate.HasValue &&
                              profile.MaritalStatus.HasValue ? true : false;

            profile.IsCompleted = isCompleted;

            if(isCompleted && profile.Resume == null)
            {
                profile.Resume = new Resume()
                {
                    DateTimeAdded = DateTime.Now
                };
            }
            await UpdateAsync(profile);
            await Task.CompletedTask;
        }

        public Profile GetByUserId(string userId)
        {
            var profile = _dbContext.Profiles.FirstOrDefault(p => p.UserId == userId && p.IsActive == true);
            return profile;
        }

        public bool IsCompleted(int id)
        {
            return _dbContext.Profiles.Find(id).IsCompleted;
        }

        public bool IsCompleted(string userId)
        {
            return _dbContext.Users
                             .Include(u => u.Profile)
                             .FirstOrDefault(u => u.Id == userId)
                             .Profile
                             .IsCompleted;
        }
    }
}

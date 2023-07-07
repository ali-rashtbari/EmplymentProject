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
    public class ConfirmationEmailRepository : GenericRepository<ConfirmationEmail>, IConfirmationEmailRepository
    {
        private readonly AppDbContext _dbContext;
        public ConfirmationEmailRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ConfirmationEmail> GetUserLastActiveConfirmationEmail(string userId)
        {
            var user = _dbContext.Users.Include(u => u.ConfirmationEmails).FirstOrDefault(u => u.Id == userId);
            var lastActiveEmail = user.ConfirmationEmails.OrderByDescending(ce => ce.DateTimeSent).Where(ce => !ce.IsConfirmed).FirstOrDefault();
            return Task.FromResult(lastActiveEmail);
        }

        public Task<ConfirmationEmail> GetUserLastConfirmationEmail(string userId)
        {
            var user = _dbContext.Users.Include(u => u.ConfirmationEmails).FirstOrDefault(u => u.Id == userId);
            var lastActiveEmail = user.ConfirmationEmails.OrderByDescending(ce => ce.DateTimeSent).FirstOrDefault();
            return Task.FromResult(lastActiveEmail);
        }
    }
}

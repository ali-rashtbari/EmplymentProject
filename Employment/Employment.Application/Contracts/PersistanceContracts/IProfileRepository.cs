using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        bool IsCompleted(int id);
        bool IsCompleted(string userId);
        Task CheckCompleteness(Profile profile);

    }
}

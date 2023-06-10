using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IJobSeniorityLevelService
    {
        Task<CommandResule<int>> AddAsync(AddJobSeniorityLevelDto addJobSeniorityLevelDto);
    }
}

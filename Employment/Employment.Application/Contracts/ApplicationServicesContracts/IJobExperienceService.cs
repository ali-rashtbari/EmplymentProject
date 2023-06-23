﻿using Employment.Application.Dtos.ApplicationServicesDtos.JobExperienceDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IJobExperienceService
    {
        Task<CommandResule<int>> AddAsync(AddJobExperienceDto addJobExperienceDto);
        GetJobExperienceDto Get(int id);
    }
}

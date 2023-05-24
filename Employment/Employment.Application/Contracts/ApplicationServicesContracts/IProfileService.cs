using Employment.Application.Dtos.ApplicationServicesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IProfileService
    {
        Task EditAsync(EditProfileDto request);
    }
}

using Employment.Application.Dtos.ApplicationServicesDtos.MajorDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IMajorService
    {
        Task<CommandResule<int>> AddAsync(AddMajorDto addMajorDto);
        IEnumerable<GetMajorsListDto> GetList();
    }
}

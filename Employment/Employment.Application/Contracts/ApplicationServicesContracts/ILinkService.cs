using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ILinkService
    {
        Task<CommandResule<int>> AddAsync(AddLinkDto addLinkDto);
        GetLinkDto Get(int id);
        IEnumerable<GetLinksListDto> GetList(int resumeId);
    }
}

using Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos;
using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ILanguageService
    {
        Task<CommandResule<int>> AddAsync(AddLanguageDto addLanguageDto);
        Task<CommandResule<int>> AddToResume(AddLanguageToResumeDto addLanguageToResumeDto);
        GetLanguageDto Get(int id);
    }
}

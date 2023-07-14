using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface ICategoryService
    {
        Task<CommandResule<int>> AddAsync(string name, int? parentId = null);
    }
}

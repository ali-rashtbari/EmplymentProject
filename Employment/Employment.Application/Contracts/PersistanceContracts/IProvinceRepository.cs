using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IProvinceRepository : IGenericRepository<Province>
    {
        bool IsExists(string name);
    }
}

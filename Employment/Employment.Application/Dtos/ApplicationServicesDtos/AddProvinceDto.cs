using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos
{
    public class AddProvinceDto
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos
{
    public class AddProvinceToCountryDto
    {
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}

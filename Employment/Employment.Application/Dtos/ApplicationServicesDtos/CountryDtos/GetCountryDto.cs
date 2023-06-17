using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CountryDtos
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvincesCount { get; set; }
        public int CitiesCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos
{
    public class GetCitiesListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string ProvinceName { get; set; }

    }
}

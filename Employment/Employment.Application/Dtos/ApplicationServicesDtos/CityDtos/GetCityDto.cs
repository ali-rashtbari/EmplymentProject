using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos
{
    public class GetCityDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProvinceName { get; set; }
        //public int ProvinceId { get; set; }
        public string CountryName { get; set; }
        //public int CountryId { get; set; }
    }
}

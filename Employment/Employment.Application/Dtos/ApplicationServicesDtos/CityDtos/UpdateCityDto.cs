using Employment.Application.Dtos.CommonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos
{
    public class UpdateCityDto : UpdateEntitiesBaseDto
    {
        public string Name { get; set; }

        [JsonIgnore]
        public int? DecodedProvinceId { get; set; } 
        public string EncodedProvinceId { get; set; }
    }
}

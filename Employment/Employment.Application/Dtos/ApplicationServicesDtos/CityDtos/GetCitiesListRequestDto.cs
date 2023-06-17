using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos
{
    public class GetCitiesListRequestDto : GetListBaseDto
    {
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.ProvinceDtos
{
    public class GetProvincesListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string CountryName { get; set; }
        public int CitiesCount { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.CityDtos
{
    public class UpdateCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; } 
    }
}

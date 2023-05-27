using AutoMapper;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.MapperProfiles
{
    public class EducationHistoryProfile : AutoMapper.Profile
    {
        public EducationHistoryProfile()
        {
            CreateMap<AddEducationHistoryDto, EducationHistory>();
        }
    }
}

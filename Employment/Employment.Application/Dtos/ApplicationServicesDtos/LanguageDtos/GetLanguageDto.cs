using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos
{
    public class GetLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResumesCount { get; set; }
    }
}

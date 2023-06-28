using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LanguageDtos
{
    public class AddLanguageToResumeDto
    {
        public int LanguageId { get; set; }
        public int ResumeId { get; set; }
        public LanguageLevel Level { get; set; }
    }
}

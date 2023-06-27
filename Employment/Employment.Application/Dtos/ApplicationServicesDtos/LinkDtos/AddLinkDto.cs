using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos
{
    public class AddLinkDto
    {
        public int ResumeId { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }

    }
}

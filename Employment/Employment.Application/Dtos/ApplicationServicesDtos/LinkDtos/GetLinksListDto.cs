using Employment.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos
{
    public class GetLinksListDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public int ResumeId { get; set; }
    }
}

using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.ApplicationServicesDtos
{
    public class EditProfileDto
    {
        public string? Biography { get; set; }
        public Gender? Gender { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

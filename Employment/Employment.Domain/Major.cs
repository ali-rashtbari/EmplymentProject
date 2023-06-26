using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Major : IAuditable
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual ICollection<EducationHistory> EducationHistories { get; set; }


        #endregion
    }
}

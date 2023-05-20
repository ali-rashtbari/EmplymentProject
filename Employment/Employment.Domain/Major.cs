using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Major
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        #region Relations 

        public virtual ICollection<EducationHistory> EducationHistories { get; set; }


        #endregion
    }
}

using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Language : DomainBaseEntity
    {
        public string Name { get; set; }

        #region Relations 

        public virtual ICollection<ResumeLanguage> ResumeLanguages { get; set; }

        #endregion
    }
}

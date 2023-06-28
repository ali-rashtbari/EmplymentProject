using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Relations

        public virtual ICollection<ResumeLanguage> ResumeLanguages { get; set; }

        #endregion
    }
}

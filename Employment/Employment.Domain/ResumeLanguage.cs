using Employment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class ResumeLanguage
    {
        public int Id { get; set; }
        public LanguageLevel Level { get; set; }

        #region Relations 

        public virtual Language Language { get; set; }
        public int LanguageId { get; set; }
        
        public virtual Resume Resume { get; set; }
        public int ResumeId { get; set; }


        #endregion
    }
}

using Employment.Common.Enums;
using Employment.Domain.BasesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class ResumeLanguage : DomainBaseEntity
    {
        public LanguageLevel Level { get; set; }


        #region Relations 

        public virtual Resume Resume { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }


        public virtual Language Language { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        #endregion
    }
}

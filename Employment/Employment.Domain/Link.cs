using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class Link
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }

        #region Relations 

        public virtual Resume Resume { get; set; }
        [ForeignKey(nameof(Resume))]
        public int ResumeId { get; set; }

        

        #endregion
    }
}

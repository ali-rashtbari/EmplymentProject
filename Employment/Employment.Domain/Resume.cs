using System.ComponentModel.DataAnnotations.Schema;

namespace Employment.Domain
{
    public class Resume : DomainBaseEntity
    {


        #region Relations 

        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfleId { get; set; }



        public virtual ICollection<Link> Links { get; set; }

        public virtual ICollection<EducationHistory> EducationHistories { get; set; }

        #endregion
    }
}

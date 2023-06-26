using System.ComponentModel.DataAnnotations.Schema;
using Employment.Domain.BasesModels;

namespace Employment.Domain
{
    public class Resume : DomainBaseEntity, IAuditable
    {
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }

        #region Relations 

        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfleId { get; set; }



        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<EducationHistory> EducationHistories { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }

        #endregion
    }
}

using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.ModelConfigurations
{
    public class EducationHistoryConfigurations : IEntityTypeConfiguration<EducationHistory>
    {
        public void Configure(EntityTypeBuilder<EducationHistory> builder)
        {


            #region Relations

            builder.HasOne(eh => eh.Resume)
                .WithMany(r => r.EducationHistories)
                .HasForeignKey(eh => eh.ResumeId)
                .IsRequired(true)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientNoAction);

            builder.HasOne(eh => eh.Major)
                .WithMany(m => m.EducationHistories)
                .HasForeignKey(eh => eh.MajorId)
                .IsRequired(true)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientNoAction);

            #endregion

        }
    }
}

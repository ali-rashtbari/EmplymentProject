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
    public class SeniorityLevelConfiguration : IEntityTypeConfiguration<JobSeniorityLevel>
    {
        public void Configure(EntityTypeBuilder<JobSeniorityLevel> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            #region Relations 

            builder.HasMany(jsl => jsl.JobExperiences)
                .WithOne(je => je.SeniorityLevel)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
            
            #endregion
        }
    }
}

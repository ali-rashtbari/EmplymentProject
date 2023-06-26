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
    public class JobExperienceConfiguration : IEntityTypeConfiguration<JobExperience>
    {
        public void Configure(EntityTypeBuilder<JobExperience> builder)
        {
            builder.Property(je => je.JobTitle)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(je => je.StartDate)
                .IsRequired(true);

            builder.Property(je => je.EndDate)
                .IsRequired(false);

            builder.Property(je => je.IsCurrentJob)
                .IsRequired(true)
                .HasDefaultValue(false);

            builder.Property(je => je.CompanyName)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(je => je.Description)
                .IsRequired(false)
                .HasMaxLength(600);

            #region Relations 

            builder.HasOne(je => je.JobCategory)
                .WithMany(jc => jc.JobExperiences)
                .HasForeignKey(je => je.JobCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(je => je.SeniorityLevel)
                .WithMany(sl => sl.JobExperiences)
                .HasForeignKey(je => je.JobSeniorityLevelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(je => je.Industry)
                .WithMany(i => i.JobExperiences)
                .HasForeignKey(je => je.InductryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(je => je.City)
                .WithMany(c => c.JobExperiences)
                .HasForeignKey(je => je.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(je => je.Resume)
                .WithMany(re => re.JobExperiences)
                .HasForeignKey(je => je.ResumeId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion

        }
    }
}

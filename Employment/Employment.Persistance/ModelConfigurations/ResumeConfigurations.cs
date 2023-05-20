using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Persistance.ModelConfigurations
{
    public class ResumeConfigurations : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {


            #region Relations

            builder.HasOne(r => r.Profile)
                .WithOne(p => p.Resume)
                .HasForeignKey<Resume>(r => r.ProfleId)
                .IsRequired(true)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientNoAction);

            builder.HasMany(r => r.Links)
                .WithOne(l => l.Resume)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.HasMany(r => r.EducationHistories)
                .WithOne(eh => eh.Resume)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            #endregion
        }
    }
}

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
    public class ProfileConfigurations : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(p => p.Biography)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(p => p.IsCompleted)
                .IsRequired(true)
                .HasDefaultValue(false);

            #region Relations

            builder.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId)
                .IsRequired(true)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientNoAction);

            builder.HasOne(p => p.Resume)
                .WithOne(r => r.Profile)
                .HasForeignKey<Profile>(p => p.ResumeId)
                .IsRequired(false)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            #endregion
        }
    }
}

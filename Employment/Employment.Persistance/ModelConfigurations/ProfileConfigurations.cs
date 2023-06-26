using Employment.Common.Enums;
using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

            builder.Property(p => p.Address)
                .IsRequired(false)
                .HasMaxLength(400);

            builder.Property(p => p.BirthDate)
                .IsRequired(false);

            builder.Property(p => p.Gender)
                .IsRequired(false)
                .HasConversion<EnumToStringConverter<Gender>>();

            builder.Property(p => p.MaritalStatus)
                .IsRequired(false)
                .HasConversion<EnumToStringConverter<MaritalStatus>>();


            #region Relations

            builder.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasOne(p => p.Resume)
                .WithOne(r => r.Profile)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            #endregion
        }
    }
}

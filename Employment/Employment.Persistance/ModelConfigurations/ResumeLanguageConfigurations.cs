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
    public class ResumeLanguageConfigurations : IEntityTypeConfiguration<ResumeLanguage>
    {
        public void Configure(EntityTypeBuilder<ResumeLanguage> builder)
        {
            builder.HasKey(rl => new { rl.ResumeId, rl.LanguageId });

            builder.HasOne(rl => rl.Resume)
                .WithMany(r => r.ResumeLanguages)
                .HasForeignKey(rl => rl.ResumeId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasOne(rl => rl.Language)
                .WithMany(l => l.ResumeLanguages)
                .HasForeignKey(rl => rl.LanguageId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.Property(rl => rl.Level)
                .IsRequired(true)
                .HasConversion<EnumToStringConverter<LanguageLevel>>();

        }
    }
}

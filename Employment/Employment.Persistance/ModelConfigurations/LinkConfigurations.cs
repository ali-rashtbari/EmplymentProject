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
    public class LinkConfigurations : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(l => l.Url)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(l => l.DisplayName)
                .IsRequired(true)
                .HasMaxLength(50);

            #region Relations 

            builder.HasOne(l => l.Resume)
                .WithMany(r => r.Links)
                .HasForeignKey(l => l.ResumeId)
                .IsRequired(true)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion
        }
    }
}

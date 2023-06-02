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
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);

        }
    }
}

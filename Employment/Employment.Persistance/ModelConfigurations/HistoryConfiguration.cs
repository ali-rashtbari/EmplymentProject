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
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.Property(h => h.PreviousValue)
                .IsRequired(false);

            builder.Property(h => h.NextValue)
                .IsRequired(false);
        }
    }
}

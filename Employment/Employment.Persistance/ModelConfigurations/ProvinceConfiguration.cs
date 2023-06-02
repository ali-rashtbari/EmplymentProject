using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.ModelConfigurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            #region Relations 

            builder.HasMany(p => p.Cities)
                .WithOne(c => c.Province)
                .OnDelete(DeleteBehavior.ClientNoAction);

            #endregion
        }
    }
}

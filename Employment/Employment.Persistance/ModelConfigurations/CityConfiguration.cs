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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            #region Relations 

            builder.HasOne(c => c.Province)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasMany(c => c.JobExperiences)
                .WithOne(je => je.City)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion
        }
    }
}

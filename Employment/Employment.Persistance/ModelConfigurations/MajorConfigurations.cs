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
    public class MajorConfigurations : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {

            builder.Property(m => m.DisplayName)
                .IsRequired(true)
                .HasMaxLength(50);


            #region Relations 

            builder.HasMany(m => m.EducationHistories)
                .WithOne(eh => eh.Major)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion

        }
    }
}

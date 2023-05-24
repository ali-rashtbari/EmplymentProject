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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(u => u.LastName)
                .IsRequired(true)
                .HasMaxLength(15);

            builder.Property(u => u.Mobile)
                .IsRequired(true)
                .HasMaxLength(11);


            #region Relations 

            builder.HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            #endregion
        }
    }
}

using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employment.Persistance.ModelConfigurations
{
    public class ConfirmationEmailConfigurations : IEntityTypeConfiguration<ConfirmationEmail>
    {
        public void Configure(EntityTypeBuilder<ConfirmationEmail> builder)
        {
            builder.Property(ce => ce.IsConfirmed)
                .IsRequired(true)
                .HasDefaultValue(false);

            builder.Property(ce => ce.DateTimeSent)
                .IsRequired(true)
                .HasDefaultValue(DateTime.Now);

            builder.Property(ce => ce.Email)
                .IsRequired(true);

            builder.Property(ce => ce.DateTimeConfirmed)
                .IsRequired(false);

            #region Relations 

            builder.HasOne(ce => ce.User)
                .WithMany(u => u.ConfirmationEmails)
                .HasForeignKey(ce => ce.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion
        }
    }
}

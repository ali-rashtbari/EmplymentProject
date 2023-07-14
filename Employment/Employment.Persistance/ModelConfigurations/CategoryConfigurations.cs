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
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasOne(chc => chc.Parent)
                .WithMany(pc => pc.Childs)
                .HasForeignKey(chc => chc.ParentId)
                .IsRequired(false)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        }
    }
}

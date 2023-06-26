﻿using Employment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.ModelConfigurations
{
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {

        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.Property(c => c.Name)
                    .IsRequired(true)
                    .HasMaxLength(50);

            #region Relations 

            builder.HasMany(jc => jc.JobExperiences)
                .WithOne(je => je.JobCategory)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            #endregion

        }
    }
}

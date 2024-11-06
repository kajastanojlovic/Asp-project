using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrition.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DataAccess.Configuration
{
    public class BodyBiometricConfiguration : EntityConfiguration<BodyBiometric>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<BodyBiometric> builder)
        {
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(b => b.Name)
                   .IsUnique();

            builder.Property(b => b.Units)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.Time)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()"); 

        }
    }
}

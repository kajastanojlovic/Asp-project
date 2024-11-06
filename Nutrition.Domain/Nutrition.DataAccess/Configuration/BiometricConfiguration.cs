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
    public class BiometricConfiguration : IEntityTypeConfiguration<Biometric>
    {
        public void Configure(EntityTypeBuilder<Biometric> builder)
        {
            builder.HasKey(mf => new { mf.BodyId, mf.UserId });

            builder.Property(mf => mf.Value)
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");

            builder.HasOne(mf => mf.User)
               .WithMany(x => x.Biometrics)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mf => mf.BodyBiometric)
              .WithMany(x => x.Biometrics)
              .HasForeignKey(x => x.BodyId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

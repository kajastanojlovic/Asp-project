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
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email)
             .IsRequired()
             .HasMaxLength(60);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(x => x.Username)
                  .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.BirthDate)
                    .IsRequired();

            builder.Property(u => u.ImagePath)
                .HasMaxLength(200);
        }
    }
}

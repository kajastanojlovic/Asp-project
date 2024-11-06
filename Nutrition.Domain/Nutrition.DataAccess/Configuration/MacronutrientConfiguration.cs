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
    public class MacronutrientConfiguration : EntityConfiguration<Macronutrient>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Macronutrient> builder)
        {
            builder.Property(m => m.Name)
                  .IsRequired()
                  .HasMaxLength(100);
            builder.HasIndex(m => m.Name)
                  .IsUnique();

            builder.HasMany(x => x.FoodMacronutrients)
                .WithOne(x => x.Macronutrient)
                .HasForeignKey(x => x.MacronutrientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    public class FoodConfiguration : EntityConfiguration<Food>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Food> builder)
        {
            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(x => x.Name)
                  .IsUnique();

            builder.Property(f => f.Brand)
                .HasMaxLength(50);
            builder.HasIndex(x => x.Brand)
                  .IsUnique();

            builder.HasMany(x => x.FoodMacronutrients)
                  .WithOne(x => x.Food)
                  .HasForeignKey(x => x.FoodId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.MealFoods)
                .WithOne(x => x.Food)
                .HasForeignKey(x => x.FoodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

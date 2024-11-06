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
    public class MealFoodConfiguration : IEntityTypeConfiguration<MealFood>
    {
        public void Configure(EntityTypeBuilder<MealFood> builder)
        {
            builder.HasKey(mf => new { mf.MealId, mf.FoodId, mf.ServingSizeId });

            builder.Property(mf => mf.Amount)
              .HasColumnType("decimal(10, 2)") 
              .IsRequired();

            builder.Property(mf => mf.ServingSizeId)
                    .IsRequired();
            builder.Property(mf => mf.FoodId)
                    .IsRequired();
            builder.Property(mf => mf.MealId)
                    .IsRequired();
        }
    }
}

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
    public class FoodMacronutrientConfiguration : IEntityTypeConfiguration<FoodMacronutrient>
    {
        public void Configure(EntityTypeBuilder<FoodMacronutrient> builder)
        {
            builder.HasKey(fm => new { fm.FoodId, fm.MacronutrientId });
            builder.Property(fm => fm.AmountMacronutrientsPer100g).IsRequired()
                .HasColumnType("decimal(10, 2)"); ;
        }
    }
}

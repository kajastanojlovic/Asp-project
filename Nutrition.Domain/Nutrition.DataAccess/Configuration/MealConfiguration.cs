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
    public class MealConfiguration : EntityConfiguration<Meal>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Meal> builder)
        {

            builder.Property(m => m.Time).IsRequired()
                    .HasDefaultValueSql("GETDATE()"); ;
            
            builder.Property(m => m.Name)
                .HasMaxLength(50);

            builder.HasOne(m => m.User)
                .WithMany(u => u.Meals)
                .HasForeignKey(m => m.UserId);

            builder.HasMany(x => x.MealFoods)
                .WithOne(x => x.Meal)
                .HasForeignKey(x => x.MealId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

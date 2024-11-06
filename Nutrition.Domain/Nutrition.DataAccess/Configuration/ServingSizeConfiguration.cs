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
    public class ServingSizeConfiguration : EntityConfiguration<ServingSize>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ServingSize> builder)
        {
            builder.Property(s => s.ServingSizeUnit).IsRequired();

            builder.Property(s => s.Amount).IsRequired();

            builder.HasMany(x => x.MealFood)
               .WithOne(x => x.ServingSize)
               .HasForeignKey(x => x.ServingSizeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

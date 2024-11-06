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
    public class DailyGoalConfiguration : EntityConfiguration<DailyGoal>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<DailyGoal> builder)
        {
            builder.Property(dg => dg.Status).IsRequired();

            builder.HasOne(dg => dg.User)
                .WithMany(u => u.DailyGoals)
                .HasForeignKey(dg => dg.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

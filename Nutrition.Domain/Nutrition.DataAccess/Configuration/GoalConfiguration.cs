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
    public class GoalConfiguration : EntityConfiguration<Goal>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Goal> builder)
        {
            builder.Property(g => g.GoalStart)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(g => g.GoalEnd)
                 .IsRequired();

            builder.Property(g => g.Height)
                 .IsRequired();

            builder.Property(g => g.StartWeight)
                 .IsRequired();
            
            builder.Property(g => g.TargetValueCaloriesPerDay)
                 .IsRequired();

            builder.HasOne(g =>g.User )
                .WithMany(x => x.Goals)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.GoalStatus)
               .WithMany(x => x.Goals)
               .HasForeignKey(x => x.GoalStatusId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

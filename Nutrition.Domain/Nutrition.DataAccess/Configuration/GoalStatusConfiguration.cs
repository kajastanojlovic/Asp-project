using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrition.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DataAccess.Configuration
{
    public class GoalStatusConfiguration : EntityConfiguration<GoalStatus>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GoalStatus> builder)
        {
            builder.Property(gs => gs.Status)
            .IsRequired()
            .HasMaxLength(20);
        }
    }
}

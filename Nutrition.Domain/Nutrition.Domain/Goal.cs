using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class Goal : Entity
    {
        public DateTime? GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public double Height { get; set; }
        public double StartWeight { get; set; }
        public int TargetValueCaloriesPerDay { get; set; }
        public int UserId { get; set; }
        public int GoalStatusId { get; set; }

        public User User { get; set; }
        public GoalStatus GoalStatus { get; set; }
    }
}

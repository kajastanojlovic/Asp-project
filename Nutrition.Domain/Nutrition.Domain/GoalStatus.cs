using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class GoalStatus : Entity
    {
        public string Status {  get; set; }
        public ICollection<Goal> Goals { get; set; } = new HashSet<Goal>();

    }
}

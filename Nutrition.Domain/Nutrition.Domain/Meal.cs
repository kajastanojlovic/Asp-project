using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class Meal : Entity
    {
        //rucak, vecera
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        

        public User User { get; set; }
        public ICollection<MealFood> MealFoods { get; set; } = new HashSet<MealFood>();


    }
}

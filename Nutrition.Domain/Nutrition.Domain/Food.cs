using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class Food : Entity
    {
        public string Name { get; set; }
        public string? Brand { get; set; }

        public ICollection<MealFood> MealFoods { get; set; } = new HashSet<MealFood>();
        public ICollection<FoodMacronutrient> FoodMacronutrients { get; set; } = new HashSet<FoodMacronutrient>();
    }
}

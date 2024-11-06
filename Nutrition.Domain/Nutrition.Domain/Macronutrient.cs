using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class Macronutrient : Entity
    {
        //proteini, ugrelji hidrati, masti
        public string Name { get; set; }
        public ICollection<FoodMacronutrient> FoodMacronutrients { get; set; } = new HashSet<FoodMacronutrient>();

    }
}

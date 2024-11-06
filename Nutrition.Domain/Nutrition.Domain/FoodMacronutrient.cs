using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class FoodMacronutrient 
    {
        
        public int FoodId { get; set; }
        public int MacronutrientId { get; set; }
        
        //kolicina makronutrienata u gramima
        public decimal AmountMacronutrientsPer100g { get; set; }

        public Macronutrient Macronutrient { get; set; }
        public Food Food { get; set; }
    }
}

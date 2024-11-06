using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class MealFood 
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public decimal Amount { get; set; }
        public int ServingSizeId { get; set; }


        public ServingSize ServingSize { get; set; }
        public Meal Meal { get; set; }
        public Food Food { get; set; }
    }
}

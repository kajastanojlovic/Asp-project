using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class ServingSize : Entity
    {
        public string ServingSizeUnit { get; set; } //g, large, small
        public int Amount { get; set; } //1g, 125g...

        public ICollection<MealFood> MealFood { get; set;}
    }
}

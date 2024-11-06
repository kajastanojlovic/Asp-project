using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.DTO
{
    public abstract class MealDto
    {
        public int Id { get; set; }

    }
    public class CreateMealDto : MealDto
    {
        public string Name { get; set; }
        
        public IEnumerable<FoodInOneMeal> FoodList { get; set; }
    }
    public class FoodInOneMeal
    {
        //merna jedinica, trenutno u gramima, samo grami
        public int ServingSizeId { get; set; }

        //kolicina koju je korisnik pojeo
        public int Amount { get; set; }
        public int FoodId { get; set; }
        //nova tablea sa ServingSize(g, large (banana)) i Value(1(g), 125(g))
    }

}

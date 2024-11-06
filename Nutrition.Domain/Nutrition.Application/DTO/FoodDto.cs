using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.DTO
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public IEnumerable<MacronutrientDto> Macronutrients { get; set; }
    }
    public class MacronutrientDto
    {
        public string Name { get; set; }
        public decimal AmountMacronutrientsPer100g { get; set; }
    }
    public class CreateFoodDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
    }
    public class DeleteFoodDto
    {
        public int Id { get; set; }
    }
}

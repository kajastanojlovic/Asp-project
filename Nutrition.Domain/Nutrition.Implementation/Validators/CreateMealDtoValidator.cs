using FluentValidation;
using Nutrition.Application.DTO;
using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class CreateMealDtoValidator : AbstractValidator<CreateMealDto>
    {
        private NutritionContext _context;

        public CreateMealDtoValidator(NutritionContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotNull()
                              .WithMessage("Meal name is required");

            RuleFor(x => x.FoodList)
                .Must(FoodExist)
                .WithMessage("Food or serving size does not exist, amount must be greater then 0.");
        }

        private bool FoodExist(IEnumerable<FoodInOneMeal> food)
        {
            if(food.Any())
            {
                //food je jedan object
                foreach (var f in food)
                {
                    if ((_context.Foods.Any(x => x.Id == f.FoodId))
                        && (_context.ServingSizes.Any(x => x.Id == f.ServingSizeId))
                        && (f.Amount > 0))
                    {
                        continue;
                       
                    }
                    else
                    {
                        return false;
                    }
                  
                }
                return true;
               
            }
            return false;
           
        }
    }
}

using FluentValidation;
using Nutrition.Application;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Meals;
using Nutrition.DataAccess;
using Nutrition.Domain;
using Nutrition.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.UseCases.Commands.Meals
{
    public class EfDeleteMealCommand : EfUseCase, IDeleteMealCommand
    {
        private readonly DeleteMealValidator _validator;
        public EfDeleteMealCommand(NutritionContext context, DeleteMealValidator validator, 
            IApplicationActor actor) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;
        public string Name => "Delete meal";

        public void Execute(MealDto data)
        {
            _validator.ValidateAndThrow(data);

            Meal meal = Context.Meals.FirstOrDefault(x => x.Id == data.Id);

            //Context.Meals.Remove(meal);
            meal.IsActive = false;
            Context.SaveChanges();

           
          
        }
    }
}

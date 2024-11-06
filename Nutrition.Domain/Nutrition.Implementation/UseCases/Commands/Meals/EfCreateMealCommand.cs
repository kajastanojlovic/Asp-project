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
    public class EfCreateMealCommand : EfUseCase, ICreateMealCommand
    {
        private readonly CreateMealDtoValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateMealCommand(NutritionContext context, IApplicationActor actor,
            CreateMealDtoValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Create meal";

        public void Execute(CreateMealDto data)
        {
            _validator.ValidateAndThrow(data);

            Meal meal = new Meal
            {
                UserId = _actor.Id ,
                Name = data.Name,
                Time = DateTime.UtcNow
            };

            var mealFood = data.FoodList.Select(x => new MealFood
            {
                Meal = meal,
                FoodId = x.FoodId,
                ServingSizeId = x.ServingSizeId,
                Amount = x.Amount
            }).ToList();

           Context.Meals.Add(meal);
            foreach(var item in mealFood)
            {
                Context.MealsFoods.Add(item);
            }

            Context.SaveChanges();
          
        }
    }
}

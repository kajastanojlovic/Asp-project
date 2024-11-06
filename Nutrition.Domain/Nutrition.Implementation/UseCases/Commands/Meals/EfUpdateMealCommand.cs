using Microsoft.EntityFrameworkCore;
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
    public class EfUpdateMealCommand : EfUseCase, IUpdateMealCommand
    {
        private readonly CreateMealDtoValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateMealCommand(NutritionContext context, CreateMealDtoValidator validator,
            IApplicationActor actor) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "Update meal";

        public void Execute(CreateMealDto data)
        {
            _validator.Validate(data);

            var meal = Context.Meals
                .Include(m => m.MealFoods)
                .SingleOrDefault(m => m.Id == data.Id);

            var existingMealFoodsMap = meal.MealFoods.ToDictionary(mf => mf.FoodId);

            meal.Name = data.Name;
            meal.Time = DateTime.UtcNow;

            Context.MealsFoods.RemoveRange(meal.MealFoods);

            var newMealFoods = data.FoodList.Select(x => new MealFood
            {
                MealId = meal.Id,
                FoodId = x.FoodId,
                ServingSizeId = x.ServingSizeId,
                Amount = x.Amount
            }).ToList();

            Context.MealsFoods.AddRange(newMealFoods);
            Context.SaveChanges();
        }
    }
}

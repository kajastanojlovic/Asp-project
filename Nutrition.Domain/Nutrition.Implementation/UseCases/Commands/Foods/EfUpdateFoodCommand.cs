using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nutrition.Application;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Foods;
using Nutrition.DataAccess;
using Nutrition.Domain;
using Nutrition.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.UseCases.Commands.Foods
{
    public class EfUpdateFoodCommand : EfUseCase, IUpdateFoodCommand
    {
        private readonly UpdateFoodValidator _validator;
    private readonly IApplicationActor _actor;
    public EfUpdateFoodCommand(NutritionContext context, UpdateFoodValidator validator,
        IApplicationActor actor) : base(context)
    {
        _actor = actor;
        _validator = validator;
    }

        public int Id => 10;

        public string Name => "Update food";

        public void Execute(FoodDto data)
        {
            _validator.ValidateAndThrow(data);

            var food = Context.Foods.FirstOrDefault(x => x.Id == data.Id);

            food.Name = data.Name;
            food.Brand = data.Brand;
            Context.FoodsMacronutrients.RemoveRange(food.FoodMacronutrients);

            var foodMacronutrients = data.Macronutrients.Select(x => 
            {
                var macronutrient = Context.Macronutrients.FirstOrDefault(m => m.Name == x.Name);

                if(macronutrient == null)
                {
                    macronutrient = new Macronutrient
                    {
                        Name = x.Name
                    };
                    Context.Macronutrients.Add(macronutrient);
                }

                return new FoodMacronutrient
                {
                    Food = food,
                    Macronutrient = macronutrient,
                    AmountMacronutrientsPer100g = x.AmountMacronutrientsPer100g
                };
            }).ToList();

            Context.FoodsMacronutrients.AddRange(foodMacronutrients);

            Context.SaveChanges();
        }
    }
}

using FluentValidation;
using Nutrition.Application;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Foods;
using Nutrition.DataAccess;
using Nutrition.Domain;
using Nutrition.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.UseCases.Commands.Foods
{
    public class EfCreateFoodCommand : EfUseCase, ICreateFoodCommand
    {
        private readonly CreateFoodDtoValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateFoodCommand(NutritionContext context, IApplicationActor actor,
            CreateFoodDtoValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Create food";

        public void Execute(CreateFoodDto data)
        {
            _validator.ValidateAndThrow(data);


            Food food = new Food
            {
               Name = data.Name,
               Brand = data.Brand
            };

            Context.Foods.Add(food);
            Context.SaveChanges();
        }
    }
}

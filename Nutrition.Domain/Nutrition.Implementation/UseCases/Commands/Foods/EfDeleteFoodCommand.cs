using Nutrition.Application.UseCases.Commands.Meals;
using Nutrition.Application;
using Nutrition.DataAccess;
using Nutrition.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition.Application.UseCases.Commands.Foods;
using Nutrition.Application.DTO;
using FluentValidation;
using Nutrition.Domain;

namespace Nutrition.Implementation.UseCases.Commands.Foods
{
    public class EfDeleteFoodCommand : EfUseCase, IDeleteFoodCommand
    {
        private readonly DeleteFoodValidator _validator;
        public EfDeleteFoodCommand(NutritionContext context, DeleteFoodValidator validator,
            IApplicationActor actor) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9 ;

        public string Name => "Delete food";

        public void Execute(DeleteFoodDto data)
        {
            _validator.ValidateAndThrow(data);

            Food food = Context.Foods.FirstOrDefault(x => x.Id == data.Id);

            //Context.Meals.Remove(meal);
            food.IsActive = false;
            Context.SaveChanges();
        }
    }
}

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
    public class DeleteMealValidator : AbstractValidator<MealDto>
    {
        private NutritionContext _context;
        public DeleteMealValidator(NutritionContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Meal Id is required")
                .Must(x => _context.Meals.Any(y => y.Id == x))
                .WithMessage("Meal with this Id does not exist.");
        }
    }
}

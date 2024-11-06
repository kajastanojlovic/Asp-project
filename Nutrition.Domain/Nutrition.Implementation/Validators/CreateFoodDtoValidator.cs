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
    public class CreateFoodDtoValidator : AbstractValidator<CreateFoodDto>
    {
        private NutritionContext _context;
        public CreateFoodDtoValidator(NutritionContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Food name is required")
                .Must(x => !context.Foods.Any(y => y.Name == x))
                .WithMessage("Food with this name already exist.");

            RuleFor(x => x.Brand)
              .NotNull()
              .WithMessage("Brand name is required");
        }
    }
}

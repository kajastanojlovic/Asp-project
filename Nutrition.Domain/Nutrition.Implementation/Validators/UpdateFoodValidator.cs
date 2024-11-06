using FluentValidation;
using Nutrition.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class UpdateFoodValidator : AbstractValidator<FoodDto>
    {
        public UpdateFoodValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Brand).NotNull().WithMessage("Brand is required");

            RuleForEach(x => x.Macronutrients).SetValidator(new MacronutrientDtoValidator());

        }
    }
    public class MacronutrientDtoValidator : AbstractValidator<MacronutrientDto>
    {
        public MacronutrientDtoValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Macronutrient Name is required")
                .NotEmpty().WithMessage("Macronutrient Name cannot be empty");

            RuleFor(x => x.AmountMacronutrientsPer100g)
                .GreaterThan(0).WithMessage("Amount of Macronutrients per 100g must be greater than 0");
        }
    }

}

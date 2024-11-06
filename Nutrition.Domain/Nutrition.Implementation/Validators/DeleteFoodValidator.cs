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
    public class DeleteFoodValidator : AbstractValidator<DeleteFoodDto>
    {
        private NutritionContext _context;
        public DeleteFoodValidator(NutritionContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Food Id is required")
                .Must(x => _context.Foods.Any(y => y.Id == x))
                .WithMessage("Food with this Id does not exist.");
        }
    }
}

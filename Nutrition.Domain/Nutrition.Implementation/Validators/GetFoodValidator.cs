using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nutrition.Application.DTO;
using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class GetFoodValidator : AbstractValidator<FoodDto>
    {
        private NutritionContext _context;
        public GetFoodValidator(NutritionContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

        }
    }
}

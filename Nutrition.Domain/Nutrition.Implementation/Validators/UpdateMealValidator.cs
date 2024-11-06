using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Nutrition.Application.DTO;
using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class UpdateMealValidator : AbstractValidator<CreateMealDto>
    {
        public UpdateMealValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");

        }
    }
}

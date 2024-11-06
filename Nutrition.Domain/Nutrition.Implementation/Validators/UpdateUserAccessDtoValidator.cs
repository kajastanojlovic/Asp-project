﻿using FluentValidation;
using Nutrition.Application.DTO;
using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class UpdateUserAccessDtoValidator : AbstractValidator<UpdateUserAccessDto>
    {
        private static int updateUserAccessId = 18;
        public UpdateUserAccessDtoValidator(NutritionContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId)
                    .Must(x => context.Users.Any(u => u.Id == x && u.IsActive))
                    .WithMessage("Requested user doesn't exist.")
                    .Must(x => !context.UserUseCases.Any(u => u.UseCaseId == updateUserAccessId && u.UserId == x))
                    .WithMessage("Not allowed to change this user.");

            RuleFor(x => x.UseCaseIds)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId)).WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");


        }
    }
}

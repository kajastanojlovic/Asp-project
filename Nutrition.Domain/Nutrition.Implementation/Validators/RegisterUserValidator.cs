using FluentValidation;
using Microsoft.AspNetCore.Http;
using Nutrition.Application.DTO;
using Nutrition.DataAccess;
using Nutrition.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nutrition.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    { 
        public RegisterUserValidator(NutritionContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
              .NotEmpty()
              .EmailAddress()
              .Must(x => !context.Users.Any(u => u.Email == x))
              .WithMessage("Email is already in use.");

            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Minimum eight characters, at least one uppercase letter, one lowercase letter and one number.");
           
            RuleFor(x => x.BirthDate).NotEmpty()
                .WithMessage("Birth date is required.");

            RuleFor(x => x.Username)
              .NotEmpty()
              .WithMessage("Username is required.")
              .Must(x => !context.Users.Any(u => u.Username == x))
              .WithMessage("Username is already in use.");

            RuleFor(x => x.GoalEnd)
                 .NotEmpty()
                .WithMessage("Goal end is required.")
                .GreaterThan(x => x.GoalStart)
                .WithMessage("The end date for the goal must be after the start date.");

            RuleFor(x => x.Height)
                .NotEmpty()
                .WithMessage("Height is required.")
                .GreaterThan(0.0)
                .WithMessage("Height must be grater then 0.");

            RuleFor(x => x.StartWeight)
                .NotEmpty()
                .WithMessage("Weight is required.")
                .GreaterThan(0.0)
                .WithMessage("Weight must be grater then 0.");

            RuleFor(x => x.TargetValueCaloriesPerDay)
                .NotEmpty()
                .WithMessage("Target calories is required.")
                .GreaterThan(0)
                .WithMessage("Target calories must be grater then 0.");

            RuleFor(x => x.ImagePath)
                .Must(x => ImageValidate(x))
                .WithMessage("Invalid image extension. Only .jpg, .jpeg and .png extensions are allowed")
                ;
        }



        private bool ImageValidate(IFormFile image)
        {
            string extension = Path.GetExtension(image.FileName);
            if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
            {
                return true;
            }
            return false;
        }

    }
}

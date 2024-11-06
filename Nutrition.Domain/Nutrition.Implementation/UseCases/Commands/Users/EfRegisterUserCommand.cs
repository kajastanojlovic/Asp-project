using FluentValidation;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Users;
using Nutrition.DataAccess;
using Nutrition.Domain;
using Nutrition.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Azure.Core;
using System.IO;
using System.IO.Pipes;

namespace Nutrition.Implementation.UseCases.Commands.Users
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommmand
    {
        public int Id => 2;

        public string Name => "UserRegistration";
        private RegisterUserValidator _validator;


        public EfRegisterUserCommand(NutritionContext context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(RegisterUserDto data)
        {
     
            _validator.ValidateAndThrow(data);


            var fileName = data.ImagePath;
            var defaultFile = "cc7a35aa-96ef-4b26-9bd3-b33b9e79d0b3.png";

            if(fileName != null)
            {
               
                var extension = Path.GetExtension(fileName.FileName);
                var newFile = Guid.NewGuid().ToString() + extension;

                var tempFile = Path.Combine("wwwroot", "temp", newFile);
                using (var fs = new FileStream(tempFile, FileMode.Create))
                {
                    fileName.CopyTo(fs);
                } ;

                var destinationFile = Path.Combine("wwwroot", "images", newFile);

                File.Move(tempFile, destinationFile, true);
                defaultFile = newFile;
            }

            User user = new User {
                BirthDate = data.BirthDate,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                ImagePath = defaultFile,
                Username = data.Username,
                UserUseCases = new List<UserUseCase>()
                {
                     new UserUseCase { UseCaseId = 3 },
                     new UserUseCase { UseCaseId = 4 },
                     new UserUseCase { UseCaseId = 5 }
                }
            };
            Goal goal = new Goal
            {
                User = user,
                GoalStart = DateTime.UtcNow,
                GoalEnd = data.GoalEnd,
                Height = data.Height,
                StartWeight = data.StartWeight,
                TargetValueCaloriesPerDay = data.TargetValueCaloriesPerDay,
                GoalStatusId = 1
            };
            //ako budem htela da korisnik unese GoalStart onda cu da stavim ternarni ? "data.GoalStart" : null
            //validaciju odradi

            Context.Users.Add(user);
            Context.Goals.Add(goal);

            Context.SaveChanges();
        }
    }
}

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

namespace Nutrition.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserAccessCommand : EfUseCase, IUpdateUserAccessCommand
    {
        private UpdateUserAccessDtoValidator _validator;
        public EfUpdateUserAccessCommand(NutritionContext context, UpdateUserAccessDtoValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 7;

        public string Name => "Modify user access";

        public void Execute(UpdateUserAccessDto data)
        {
            _validator.Validate(data);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == data.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            Context.UserUseCases.AddRange(data.UseCaseIds.Select(x =>
            new Domain.UserUseCase
            {
                UserId = data.UserId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}

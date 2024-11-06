using Nutrition.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.UseCases.Commands.Foods
{
    public interface IDeleteFoodCommand : ICommand<DeleteFoodDto>
    {
    }
}

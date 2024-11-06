using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Meals;
using Nutrition.Application.UseCases.Queries;
using Nutrition.Implementation;
using System.Reflection.Metadata;

namespace Nutrition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public MealController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }


        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateMealDto dto,
                               [FromServices] ICreateMealCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromBody] MealDto dto,
                             [FromServices] IDeleteMealCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeal(int id, [FromBody] CreateMealDto dto,
                                                [FromServices] IUpdateMealCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Foods;
using Nutrition.Application.UseCases.Commands.Meals;
using Nutrition.Application.UseCases.Queries;
using Nutrition.Implementation;

namespace Nutrition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public FoodController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] FoodSearch search, [FromServices] IGetFoodQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateFoodDto dto,
                              [FromServices] ICreateFoodCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteFoodDto dto,
                          [FromServices] IDeleteFoodCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFood(int id, [FromBody] FoodDto dto,
                                              [FromServices] IUpdateFoodCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}

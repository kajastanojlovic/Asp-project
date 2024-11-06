using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Commands.Users;
using Nutrition.Implementation;

namespace Nutrition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UsersController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] RegisterUserDto dto, [FromServices] IRegisterUserCommmand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateUserAccessDto dto,
                                                [FromServices] IUpdateUserAccessCommand command)
        {
            dto.UserId = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}

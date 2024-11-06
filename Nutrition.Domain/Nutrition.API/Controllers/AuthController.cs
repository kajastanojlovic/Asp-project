using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.API.Core;
using Nutrition.API.DTO;

namespace Nutrition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _tokenCreator;

        public AuthController(JwtTokenCreator tokenCreator)
        {
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            string token = _tokenCreator.Create(request.Username, request.Password);

            return Ok(new AuthResponse { Token = token });
        }
    }
}

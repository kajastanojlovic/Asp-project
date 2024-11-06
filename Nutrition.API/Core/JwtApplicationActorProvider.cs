using Newtonsoft.Json;
using Nutrition.Application;
using Nutrition.Implementation;
using System.IdentityModel.Tokens.Jwt;

namespace Nutrition.API.Core
{
    public class JwtApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;

        public JwtApplicationActorProvider(string authorizationHeader)
        {
            _authorizationHeader = authorizationHeader;
        }
        public IApplicationActor GetActor()
        {
            if (_authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedActor();
            }
            string token = _authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var actor = new Actor
            {
                Id = int.Parse(claims.First(x => x.Type == "Id").Value),
                Username = claims.First(x => x.Type == "Username").Value,
                AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.First(x => x.Type == "UseCaseIds").Value)

            };
            return actor;
        }
    }
}

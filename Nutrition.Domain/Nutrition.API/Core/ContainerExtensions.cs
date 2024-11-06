using System.IdentityModel.Tokens.Jwt;

namespace Nutrition.API.Core
{
    public static class ContainerExtensions
    {
        public static Guid? GetTokenId(this HttpRequest request)
        //metoda se izvrsava nad requestom koji smo pozvali - this HttpRequest request
        //context.HttpContext.Request.GetTokenId().Value;
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}

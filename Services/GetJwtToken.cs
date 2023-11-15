using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.Help;

namespace ShopAPI2.Services
{
    public class GetJwtToken
    {
        public User user;
        public GetJwtToken(User user)
        {
            if (user == null)
            {
                throw new Exception("User is null");
            }

            this.user = user;
        }

        public string Get()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Title)
            };

            var jwt = new JwtSecurityToken(
                issuer:JwtTokenOptions.ISUURE,
                audience: JwtTokenOptions.AUDIENCE,
                claims:claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: new SigningCredentials(JwtTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static string[] DecodeToken(string key)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(key);

            string[] JwtDecode = new string[jwtSecurityToken.Claims.Count()];

            for (int i = 0;i<jwtSecurityToken.Claims.Count();i++)
            {
                JwtDecode[i] = jwtSecurityToken.Claims.ToArray()[i].Value;
            }

            return JwtDecode;
        }
    }
}

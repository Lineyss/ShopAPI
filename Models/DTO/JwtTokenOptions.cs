using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShopAPI2.Models.ViewModels
{
    public class JwtTokenOptions
    {
        public static readonly string ISUURE = "DataBaseAPI";
        public static readonly string AUDIENCE = "APIUser";
        private const string Key = "IJustDrankACocktailInWhichTequilaWithStrawberriesWasDelicious";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}

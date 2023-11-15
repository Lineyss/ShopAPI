using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Services;

namespace ShopAPI2.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {

        }

        public UserDTO(User user)
        {
            ID = user.ID;
            Login = user.Login;
            Password = user.Password;
            SecondName = user.SecondName;
            FirstName = user.FirstName;
            MidleName = user.MidleName;
            Phone = user.Phone;
            Email = user.Email;
            Role = user.Role.Title;
        }
        public int ID { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Services;

namespace ShopAPI2.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            ID = user.ID;
            Login = user.Login;
            HashPassword = user.Password;
            SecondName = user.SecondName;
            FirstName = user.FirstName;
            MidleName = user.MidleName;
            Phone = user.Phone;
            Email = user.Email;
            Role = user.Role.Title;
        }
        public int ID { get; private set; }
        public string Login { get; set; }

        private string HashPassword;
        public string Password
        {
            get
            {
                return HashPassword;
            }
            set
            {
                HashPassword = PasswordHash.hashPassword(value);
            }
        }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

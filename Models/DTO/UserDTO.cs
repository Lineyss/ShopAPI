using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public UserDTO(UserPOSTDTO user)
        {
            ID = 0;
            Login = user.Login;
            Password = user.Password;
            SecondName = user.SecondName;
            FirstName = user.FirstName;
            MidleName = user.MidleName;
            Phone = user.Phone;
            Email = user.Email;
            IDRole = user.IDRole;
        }

        public int GetRoleID()
        {
            return IDRole;
        }

        public int ID { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }
        [MaxLength(30)]
        [Required]
        public string SecondName { get; set; }
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [Required]
        public string MidleName { get; set; }
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
        [MaxLength(30)]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        private int IDRole { get; set; }
    }
}

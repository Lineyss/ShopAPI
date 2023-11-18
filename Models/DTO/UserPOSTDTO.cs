using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShopAPI2.Models.DTO
{
    public class UserPOSTDTO
    {
        public UserPOSTDTO()
        {

        }

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
        public int IDRole { get; set; }
    }
}

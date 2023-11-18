using ShopAPI2.Models.DataBaseModels;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models.DTO
{
    public class RoleDTO
    {
        public RoleDTO()
        {

        }

        public RoleDTO(Role role)
        {
            ID = role.ID;
            Title = role.Title;
        }

        public RoleDTO(string Title)
        {
            ID = 0;
            this.Title = Title;
        }

        public int ID { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}

using ShopAPI2.Models.DataBaseModels;

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

        public int ID { get; private set; }
        public string Title { get; set; }
    }
}

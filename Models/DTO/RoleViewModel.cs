using ShopAPI2.Models.DataBaseModels;

namespace ShopAPI2.Models.DTO
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {

        }

        public RoleViewModel(Role role)
        {
            ID = role.ID;
            Title = role.Title;
            this.role = role;
        }

        public static List<RoleViewModel> Builder(IEnumerable<Role> roles)
        {
            List<RoleViewModel> returnRoles = new List<RoleViewModel>();
            foreach(var element in roles)
            {
                returnRoles.Add(new RoleViewModel(element));
            }

            return returnRoles;
        }

        public Role Create()
        {
            role.Title = Title;
            return role;
        }

        public Role Update(int ID)
        {
            role.ID = ID;
            role.Title = Title;
            return role;
        }

        public int ID { get; private set; }
        public string Title { get; set; }

        private Role role = new Role();
    }
}

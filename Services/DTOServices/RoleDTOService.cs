using Microsoft.EntityFrameworkCore;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Services.DTOServices
{
    public class RoleDTOService : IDTOServices<RoleDTO>
    {
        private readonly DataBaseWorker db;
        public RoleDTOService(DataBaseWorker db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            return await db.roles.Select(element => new RoleDTO(element)).ToListAsync();
        }

        public async Task<RoleDTO?> GetBy(int ID)
        {
            Role? role = await db.roles.FirstOrDefaultAsync(element => element.ID == ID);

            if (role == null)
                return null;

            return new RoleDTO(role);
        }

        public async Task<RoleDTO?> GetBy(string value)
        {
            Role? role = await db.roles.FirstOrDefaultAsync(element => element.Title == value);

            if (role == null)
                return null;

            return new RoleDTO(role);
        }

        public async Task<RoleDTO> Create(RoleDTO element)
        {
            Role? role = await db.roles.FirstOrDefaultAsync(item => item.Title == element.Title);

            if (role != null)
                return null;

            role = new Role();
            role.Title = element.Title;

            db.roles.Add(role);
            db.SaveChanges();
            return new RoleDTO(role);
        }

        public async Task<bool> Delete(int ID)
        {
            Role? role = await db.roles.FirstOrDefaultAsync(element => element.ID == ID);

            if (role == null)
                return false;

            db.roles.Remove(role);
            db.SaveChanges();

            return true;
        }

        public async Task<RoleDTO?> Update(int ID, RoleDTO element)
        {
            Role? role = await db.roles.FirstOrDefaultAsync(item => item.ID == ID);

            if (role == null)
                return null;

            role.Title = element.Title;
            db.SaveChanges();

            return new RoleDTO(role);
        }
    }
}

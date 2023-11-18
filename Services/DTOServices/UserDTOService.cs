using Microsoft.EntityFrameworkCore;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;

namespace ShopAPI2.Services.DTOServices
{
    public class UserDTOService: IDTOServices<UserDTO>
    {
        private readonly DataBaseWorker db;
        public UserDTOService(DataBaseWorker db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await db.users.Include(element=> element.Role).Select(element => new UserDTO(element)).ToListAsync();
        }

        public async Task<UserDTO?> GetBy(int ID)
        {
            User? user = await db.users.Include(element => element.Role).FirstOrDefaultAsync(element=> element.ID == ID);

            return user == null ? null : new UserDTO(user);
        }

        public async Task<UserDTO?> GetBy(string value)
        {
            if (value == null)
                return null;

            User? user = await db.users.Include(element => element.Role).FirstOrDefaultAsync(element => element.Login == value);

            return user == null ? null : new UserDTO(user);
        }

        public async Task<UserDTO> Create(UserDTO element)
        {
            if (element == null)
                return null;

            User? user = await db.users.FirstOrDefaultAsync(item => item.Login == element.Login);
            Role? role = await db.roles.FirstOrDefaultAsync(item => item.ID == element.GetRoleID());

            if (user != null || role == null)
                return null;

            user = new User();

            user.Login = element.Login;
            user.Password = PasswordHash.hashPassword(element.Password);
            user.FirstName = element.FirstName;
            user.SecondName = element.SecondName;
            user.MidleName = element.MidleName;
            user.Phone = element.Phone;
            user.Email = element.Email;
            user.RoleID = role.ID;
            user.Role = role;

            db.users.Add(user);
            db.SaveChanges();

            return new UserDTO(user);
        }

        public async Task<bool> Delete(int ID)
        {
            User? user = await db.users.FirstOrDefaultAsync(element => element.ID == ID);
            if (user == null)
                return false;

            db.users.Remove(user);
            db.SaveChanges();
            return true;

        }

        public async Task<UserDTO?> Update(int ID, UserDTO element)
        {
            if (element == null)
                return null;

            User? user = await db.users.FirstOrDefaultAsync(item => item.ID == ID);
            Role? role = await db.roles.FirstOrDefaultAsync(item => item.Title == element.Role);

            if (user == null || role == null)
                return null;

            user.Login = element.Login;
            user.Password = element.Password;
            user.FirstName = element.FirstName;
            user.MidleName = element.MidleName;
            user.RoleID = role.ID;
            user.Role = role;

            db.SaveChanges();

            return new UserDTO(user);
        }
    }
}
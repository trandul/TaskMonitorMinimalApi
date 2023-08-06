using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Repositories
{
    public class AuthRepository : IAuth
    {
        private ApplicationContext _db;
        public AuthRepository(ApplicationContext db)
        {
            _db = db;
        }

        public UserDTO? Login(string login, string password)
        {
            var user = _db.Users.Include(c=>c.Role).FirstOrDefault(x=>x.Login == login && x.Password == password);
            if (user!=null)
            {
                return new UserDTO(user);
            }
            return null;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public UserDTO? Register(UserRegisterDTO userRegister)
        {
            try
            {
                var user = new User(userRegister);
                user.Role = _db.Roles.FirstOrDefault(x => x.Name == "User");
                _db.Users.Add(user);
                _db.SaveChanges();
                return new UserDTO(_db.Users.FirstOrDefault(x=>x.Login == user.Login));
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}

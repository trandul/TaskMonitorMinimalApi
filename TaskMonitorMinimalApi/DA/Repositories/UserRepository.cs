using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.Models;

namespace TaskMonitorMinimalApi.DA.Repositories
{
    public class UserRepository : IAuth
    {
        private ApplicationContext _db;
        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string password)
        {
            var user = new User { Id = Guid.NewGuid(), Login = username, Password = password, Name = "", Email = "", LastName = "",Role = _db.Roles.FirstOrDefault(x=>x.Name == "User") };
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}

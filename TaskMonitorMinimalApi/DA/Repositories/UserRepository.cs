using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.DA.EF;
using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.DA.Interfaces;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _db;
        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void AddJob(string login, Guid JobId)
        {
            var user = _db.Users.Include(x=>x.AssignedJobs).FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                var Job = _db.Jobs.FirstOrDefault(x => x.Id == JobId);
                if (Job != null)
                {
                    if (user.AssignedJobs==null)
                        user.AssignedJobs = new List<Job>();
                    user.AssignedJobs.Add(Job);
                    _db.SaveChanges();
                }
            }
        }

        public void Delete(string login)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == login);
            if (user!=null)
            {
                _db.Users.Remove(user);
            }
        }

        public void DeleteJob(string login, Guid JobId)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                var Job = _db.Jobs.FirstOrDefault(x => x.Id == JobId);
                if (Job != null)
                {
                    user.AssignedJobs.Remove(Job);
                    _db.SaveChanges();
                }
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _db.Users
                .Include(x=>x.Role)
                .Select(x => new UserDTO(x)).ToList();
        }

        public UserDTO? GetByLogin(string login)
        {
            var user = _db.Users
                .Include(x=>x.Role)
                .Include(x=>x.AssignedJobs)
                .FirstOrDefault(u => u.Login == login);
            if (user!=null)
            {
                return new UserDTO(user);
            }
            return null;
            
        }

        public void SetRole(string login, string role)
        {
            var user = _db.Users
                .Include(x=>x.Role)
                .FirstOrDefault(x => x.Login == login);
            if (user!=null)
            {
                var _role = _db.Roles.FirstOrDefault(x => x.Name == role);
                if (_role != null)
                {
                    user.Role = _role;
                    _db.SaveChanges();
                }
            }
        }

        public void Update(UserRegisterDTO entity)
        {
            var user = _db.Users
                .Include(x=>x.Role)
                .FirstOrDefault(x=>x.Login==entity.Login && x.Password == entity.Password);
            if (user!=null)
            {
                user.Login = entity.Login;
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                _db.SaveChanges();
            }
        }
    }
}

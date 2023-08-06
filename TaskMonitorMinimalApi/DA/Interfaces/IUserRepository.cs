using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetByLogin(string login);
        void Update(UserRegisterDTO entity);
        void Delete(string login);
        void SetRole(string login, string role);
        void AddJob(string login, Guid JobId);
        void DeleteJob(string login, Guid JobId);
    }
}

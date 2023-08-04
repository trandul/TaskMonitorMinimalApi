using TaskMonitorMinimalApi.Models;

namespace TaskMonitorMinimalApi.DA.Interfaces
{
    public interface IAuth
    {
        void Register(string username, string password);
        void Login(string username, string password);
        void Logout();
    }
}

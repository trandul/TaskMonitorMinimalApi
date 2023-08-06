using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Interfaces
{
    public interface IAuth
    {
        UserDTO? Register(UserRegisterDTO userRegister);
        UserDTO? Login(string login, string password);
        void Logout();
    }
}

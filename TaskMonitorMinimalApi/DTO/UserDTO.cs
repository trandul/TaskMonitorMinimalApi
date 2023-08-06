using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskMonitorMinimalApi.DA.Entities;

namespace TaskMonitorMinimalApi.DTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public UserDTO(User user)
        {
            Login = user.Login;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role.Name;
        }
    }
}

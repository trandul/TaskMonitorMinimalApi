using System.ComponentModel.DataAnnotations.Schema;
using TaskMonitorMinimalApi.DTO;

namespace TaskMonitorMinimalApi.DA.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Job>? AssignedJobs { get; set; }
        public ICollection<Job>? ManagedJobs { get; set; }
        public User() { }
        public User(UserRegisterDTO user)
        {
            Id = Guid.NewGuid();
            Login = user.Login;
            Password = user.Password;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
        }
    }
}

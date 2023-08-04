using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMonitorMinimalApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Objective>? AssignedObjectives { get; set; }
        public ICollection<Objective>? ManagedObjectives { get; set; }
    }
}

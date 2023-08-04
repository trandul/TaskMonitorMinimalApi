using System.ComponentModel.DataAnnotations.Schema;
using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.Models
{
    public class Objective
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public DateTime Completed { get; set; }
        public TaskPriority Priority { get; set; }
        public ICollection<User>? Performers { get; set; }
        public Guid ManagerId { get; set; }
        public User? Manager { get; set; }
    }
}

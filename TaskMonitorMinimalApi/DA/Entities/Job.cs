using System.ComponentModel.DataAnnotations.Schema;
using TaskMonitorMinimalApi.DTO;
using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.DA.Entities
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public DateTime Completed { get; set; }
        public TaskPriority Priority { get; set; }
        public ICollection<User> Performers { get; set; }
        public Guid ManagerId { get; set; }
        public User Manager { get; set; }
        public Job() { }
        public Job(JobCreateDTO job)
        {
            Id = Guid.NewGuid();
            Name = job.Name;
            Created = job.Created;
            Expired = job.Expired;
            Priority = job.Priority;
        }
    }
}

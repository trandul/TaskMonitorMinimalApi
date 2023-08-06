using TaskMonitorMinimalApi.DA.Entities;
using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.DTO
{
    public class JobDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public DateTime Completed { get; set; }
        public TaskPriority Priority { get; set; }
        public ICollection<UserDTO>? Performers { get; set; }
        public UserDTO Manager { get; set; }
        public JobDTO(Job Job)
        {
            Id = Job.Id;
            Name = Job.Name;
            Created = Job.Created;
            Expired = Job.Expired;
            Completed = Job.Completed;
            Priority = Job.Priority;
            Performers = Job.Performers.Select(x => new UserDTO(x)).ToList();
            Manager = new UserDTO(Job.Manager);
        }
    }
}

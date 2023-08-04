using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.Models
{
    public class ObjectiveCreate
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid[]? PerformersId { get; set; }
        public Guid ManagerId { get; set; }
    }
}

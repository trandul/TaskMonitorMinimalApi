using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.DTO
{
    public class JobCreateDTO
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public TaskPriority Priority { get; set; }
        public string[]? PerformersLogins { get; set; }
        public string ManagerLogin { get; set; }
    }
}

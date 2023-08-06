using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.DTO
{
    public class JobUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Expired { get; set; }
        public DateTime Completed { get; set; }
        public TaskPriority Priority { get; set; }
        public string[]? PerformersLogins { get; set; }
        public string ManagerLogin { get; set; }
    }
}

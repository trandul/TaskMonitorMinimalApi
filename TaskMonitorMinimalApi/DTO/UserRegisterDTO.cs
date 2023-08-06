using System.ComponentModel.DataAnnotations;

namespace TaskMonitorMinimalApi.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}

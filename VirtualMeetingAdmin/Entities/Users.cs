using System.ComponentModel.DataAnnotations;

namespace VirtualMeetingAdmin.Entities
{
    public class Users : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 7)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Address { get; set; } = string.Empty;
    }

    //public class UsersViewModel
    //{
    //    public List<Users>? _Users { get; set; }
    //    public string? filterUser { get; set; }
    //    public string? filterEmail { get; set; }
    //}
}

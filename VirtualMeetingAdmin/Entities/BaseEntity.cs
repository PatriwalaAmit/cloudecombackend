using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualMeetingAdmin.Entities
{
    public enum RecordStatus
    {
        Inserted = 0,
        Updated = 1,
        Deleted = 2
    }
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "SYSTEM";

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Status { get; set; } = 0;
    }
}

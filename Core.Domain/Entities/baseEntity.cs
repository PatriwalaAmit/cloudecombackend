using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class baseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "SYSTEM";
        public int Status { get; set; } = 0; /* 0 insert, 1 updated, 2 inactive */
    }
}

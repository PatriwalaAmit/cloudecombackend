using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Users : baseEntity
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}

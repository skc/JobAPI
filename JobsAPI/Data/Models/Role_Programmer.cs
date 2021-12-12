using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class Role_Programmer
    {
        public int Role_programmerId { get; set; }
        public int RoleId { get; set; }
        public int Order { get; set; }
        public string ProgarmmerId { get; set; }
        public Role Role { get; set; }
    }
}

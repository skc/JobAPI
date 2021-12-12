using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Dc { get; set; }
        public string Application { get; set; }
        public string Name { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedAt { get; set; }

        public List<Role_Programmer> Role_Programmers { get; set; }
    }
}

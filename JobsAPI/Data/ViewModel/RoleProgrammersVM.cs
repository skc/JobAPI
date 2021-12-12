using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models.ViewModel
{
    public class RoleProgrammersVM
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<string> ProgrammerIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.ViewModel
{
    public class JobDefVM
    {
        public string Dc { get; set; }
        public string Application { get; set; }
        public string Group { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public int JobId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class ProgrammersNote
    {
        public int ProgrammersNoteId { get; set; }
        public string Text { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

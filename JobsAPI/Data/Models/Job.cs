using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Dc { get; set; }
        public string Application { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCritical { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }

        public List<InfoNote> InfoNotes { get; set; }
        public List<ProgrammersNote> ProgrammersNotes { get; set; }
        public List<OperatorsNote> OperatorsNotes { get; set; }
    }
}

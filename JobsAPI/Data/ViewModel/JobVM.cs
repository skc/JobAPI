using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.ViewModel
{
    public class JobVM
    {
        public string Dc { get; set; }
        public string Application { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCritical { get; set; }
        public List<InfoNoteVM> InfoNotes { get; set; }
        public List<OperatorsNoteVM> OperatorsNotes { get; set; }
        public List<ProgrammersNoteVM> ProgrammersNotes { get; set; }
    }
}

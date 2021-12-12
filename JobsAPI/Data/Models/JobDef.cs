using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    [Table("DEF_JOB")]
    public class JobDef
    {
        [Column("DC")]
        public string Dc { get; set; }
        [Column("APPLICATION")]
        public string Application { get; set; }
        [Column("GROUP")]
        public string Group { get; set; }
        [Column("JOBNAME")]
        public string JobName { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}

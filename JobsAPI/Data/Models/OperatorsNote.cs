using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class OperatorsNote
    {
        public int OperatorsNoteId { get; set; }
        public string Text { get; set; }
        public bool RtL { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int JobId { get; set; }
        [JsonIgnore]
        public virtual Job Job { get; set; }
    }
}

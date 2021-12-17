using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class InfoNote
    {
        public int InfoNoteId { get; set; }
        public string Text { get; set; }
        public bool RtL { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
       
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}

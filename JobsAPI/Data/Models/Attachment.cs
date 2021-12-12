using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string Dc { get; set; }
        public string Application { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}

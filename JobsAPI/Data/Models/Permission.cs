using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string User { get; set; }
        public string Dc { get; set; }
        public string Application { get; set; }
        public bool MayGrant { get; set; }
        public string  GrantedBy { get; set; }
        public DateTime GrantedAt { get; set; }
    }
}

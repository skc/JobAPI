using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.ViewModel
{
    public class PermissionVM
    {
        public string User { get; set; }
        public ApplicationVM App { get; set; }
        public bool MayGrant { get; set; }

        public PermissionVM(string user, string dc, string application, bool mayGrant)
        {
            User = user;
            MayGrant = mayGrant;
            App = new ApplicationVM() { Dc = dc, Application = application };
        }

        public PermissionVM(string user, string dc, string application) : this(user, dc, application, true)
        {

        }
    }
}

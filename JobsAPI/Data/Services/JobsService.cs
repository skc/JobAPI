using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Services
{
    public class JobsService
    {
        private JobsDbContext _context;
        public JobsService(JobsDbContext context)
        {
            _context = context;
        }
    }
}

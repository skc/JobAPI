using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Services
{
    public class AttachmentsService
    {
        private JobsDbContext _context;
        public AttachmentsService(JobsDbContext context)
        {
            _context = context;
        }
    }
}

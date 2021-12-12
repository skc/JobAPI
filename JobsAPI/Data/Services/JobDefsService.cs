using JobsAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Services
{
    public class JobDefsService
    {
        private EmDbContext _context;
        public JobDefsService(EmDbContext context)
        {
            _context = context;
        }
        public List<JobDef> GetJobDefsByApplication(string dc, string application) =>
            _context.JobDefs.Where(jd => jd.Dc == dc && jd.Application == application).ToList();

        public List<string> GetAllApplications() =>
            _context.JobDefs.Select(jd => jd.Application).Distinct().ToList();
    }
}

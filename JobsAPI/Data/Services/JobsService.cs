using JobsAPI.Data.Models;
using JobsAPI.Data.ViewModel;
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
        public bool IsJobExists(string dc, string application, string group, string jobname) =>
            _context.Jobs.FirstOrDefault(j =>
            j.Dc == dc && j.Application == application && j.Group == group && j.Name == jobname) != null;

        public void AddJob(JobVM jobVM, string user)
        {
            var job = new Job()
            {
                Dc = jobVM.Dc,
                Application = jobVM.Application,
                Group = jobVM.Group,
                Name = jobVM.Name,
                Description = jobVM.Description,
                IsCritical = jobVM.IsCritical,
                InfoNotes = jobVM.InfoNotes.Select(n => new InfoNote()
                {
                    Text = n.Text,
                    AttachmentId = n.AttachmentId,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList(),
                ProgrammersNotes = jobVM.ProgrammersNotes.Select(n => new ProgrammersNote()
                {
                    Text = n.Text,
                    RoleId = n.RoleId,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList(),
                OperatorsNotes = jobVM.OperatorsNotes.Select(n => new OperatorsNote()
                {
                    Text = n.Text,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList(),
                CreatedBy = user,
                CreatedAt = DateTime.Now
            };
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }
}

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
            var infoNotes = new List<InfoNote>() { };
            if (jobVM.InfoNotes != null)
                infoNotes = jobVM.InfoNotes.Select(n => new InfoNote()
                {
                    Text = n.Text,
                    AttachmentId = n.AttachmentId,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();

            var programmersNotes = new List<ProgrammersNote>() { };
            if (jobVM.ProgrammersNotes != null)
                programmersNotes = jobVM.ProgrammersNotes.Select(n => new ProgrammersNote()
                {
                    Text = n.Text,
                    RoleId = n.RoleId,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();

            var operatorsNotes = new List<OperatorsNote>() { };
            if (jobVM.OperatorsNotes != null)
                operatorsNotes = jobVM.OperatorsNotes.Select(n => new OperatorsNote()
                {
                    Text = n.Text,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();

            var job = new Job()
            {
                Dc = jobVM.Dc,
                Application = jobVM.Application,
                Group = jobVM.Group,
                Name = jobVM.Name,
                Description = jobVM.Description,
                IsCritical = jobVM.IsCritical,
                InfoNotes = infoNotes,
                ProgrammersNotes = programmersNotes,
                OperatorsNotes = operatorsNotes,
                CreatedBy = user,
                CreatedAt = DateTime.Now
            };
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public Job GetJob(int id)
        {
            var job = _context.Jobs.FirstOrDefault(j => j.JobId == id);
            if (job == null)
                return null;
            job.InfoNotes = _context.InfoNotes.Where(n => n.JobId == id).ToList();
            job.ProgrammersNotes = _context.ProgrammersNotes.Where(n => n.JobId == id).ToList();
            job.OperatorsNotes = _context.OperatorsNotes.Where(n => n.JobId == id).ToList();
            return job;
        }
        public List<JobDefVM> GetJobIds(List<JobDef> jobs) =>
            jobs.Select(j => new JobDefVM()
            {
                Dc = j.Dc,
                Application = j.Application,
                Group = j.Group,
                JobName = j.JobName,
                JobId = GetJobId(j.Dc, j.Application, j.Group, j.JobName)
            }).ToList();

        public int GetJobId(string dc, string application, string group, string name)
        {
            var job = _context.Jobs.FirstOrDefault(j =>
                j.Dc == dc && j.Application == application && j.Group == group && j.Name == name);
            if (job == null)
                return -1;
            return job.JobId;
        }

        public void UpdateJob(int id, JobVM job, string user)
        {
            var infoNotes = _context.InfoNotes.Where(n => n.JobId == id).ToList();
            var programmersNotes = _context.ProgrammersNotes.Where(n => n.JobId == id).ToList();
            var operatorsNotes = _context.OperatorsNotes.Where(n => n.JobId == id).ToList();

            if (job.InfoNotes != null)
            {
                _context.InfoNotes.RemoveRange(infoNotes);
                infoNotes = job.InfoNotes.Select(n => new InfoNote()
                {
                    Text = n.Text,
                    RtL = n.RtL,
                    AttachmentId = n.AttachmentId,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();
            }
            if (job.ProgrammersNotes != null)
            {
                _context.ProgrammersNotes.RemoveRange(programmersNotes);
                programmersNotes = job.ProgrammersNotes.Select(n => new ProgrammersNote()
                {
                    Text = n.Text,
                    RtL = n.RtL,
                    RoleId = n.RoleId,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();
            }
            if (job.OperatorsNotes != null)
            { 
                _context.OperatorsNotes.RemoveRange(operatorsNotes);
                operatorsNotes = job.OperatorsNotes.Select(n => new OperatorsNote()
                {
                    Text = n.Text,
                    RtL = n.RtL,
                    UpdatedBy = user,
                    UpdatedAt = DateTime.Now
                }).ToList();
            }
            var _job = _context.Jobs.First(j => j.JobId == id);
            _job.IsCritical = job.IsCritical;
            _job.InfoNotes = infoNotes;
            _job.ProgrammersNotes = programmersNotes;
            _job.OperatorsNotes = operatorsNotes;
            _job.ChangedBy = user;
            _job.ChangedAt = DateTime.Now;

            _context.Jobs.Update(_job);
            _context.SaveChanges();
        }

        public void DeleteJob(int id)
        {
            var job = _context.Jobs.Find(id);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }
    }
}

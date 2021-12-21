using JobsAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobsAPI.Data.ViewModel;
using Microsoft.Extensions.Configuration;
using JobsAPI.Helpers;

namespace JobsAPI.Controllers
{
    public class JobsController : ControllerBase
    {
        private JobsService _jobsService;
        private PermissionsService _permissionsService;
        private IConfiguration _configuration;
        public JobsController(JobsService jobsService, PermissionsService permissionsService, IConfiguration cofiguration)
        {
            _jobsService = jobsService;
            _permissionsService = permissionsService;
            _configuration = cofiguration;
        }

        [HttpPost("add-job-by-operator")]
        public IActionResult AddJobByOperator([FromBody] JobVM job)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            if (!_permissionsService.IsOperator(user, _configuration))
            {
                return StatusCode(403, $"User is not an operator");
            }
            if (job.ProgrammersNotes != null || job.InfoNotes != null)
            {
                return StatusCode(403, $"User is not permitted for programmers or info notes");
            }
            if (_jobsService.IsJobExists(job.Dc, job.Application, job.Group, job.Name))
            {
                return BadRequest("Job already exists");
            }
            _jobsService.AddJob(job, user);
            return Ok();
        }

        [HttpPost("add-job")]
        public IActionResult AddJob([FromBody] JobVM job)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, job.Dc, job.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return StatusCode(403, $"User not premitted to for application: {perm.App.Dc} - {perm.App.Application}");
            }
            if (job.OperatorsNotes != null && !_permissionsService.IsOperator(user, _configuration))
            {
                return StatusCode(403, $"User is not permitted for operators notes");
            }
            if (_jobsService.IsJobExists(job.Dc, job.Application, job.Group, job.Name))
            {
                return BadRequest("Job already exists");
            }
            _jobsService.AddJob(job, user);
            return Ok();
        }

        [HttpGet("get-job-by-id/{id}")]
        public IActionResult GetJobById(int id)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var job = _jobsService.GetJob(id);
            if (job == null)
            {
                return BadRequest("Job not exists");
            }
            if (_permissionsService.IsOperator(user, _configuration))
            {
                return Ok(job);
            }
            var perm = new PermissionVM(user, job.Dc, job.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return StatusCode(403, $"User not premitted to for application: {perm.App.Dc} - {perm.App.Application}");
            }
            return Ok(job);
        }
        
        [HttpPut("update-job")]
        public IActionResult UpdateJob([FromBody] JobVM job)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, job.Dc, job.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return StatusCode(403, $"User not premitted to for application: {perm.App.Dc} - {perm.App.Application}");
            }
            if (job.OperatorsNotes != null && !_permissionsService.IsOperator(user, _configuration))
            {
                return StatusCode(403, $"User is not permitted for operators notes");
            }
            var jobId = _jobsService.GetJobId(job.Dc, job.Application, job.Group, job.Name);
            if (jobId < 0)
            {
                return BadRequest("Job not exists");
            }
            _jobsService.UpdateJob(jobId, job, user);
            return Ok();
        }

        [HttpDelete("delete-job/{id}")]
        public IActionResult DeleteJob(int id)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var job = _jobsService.GetJob(id);
            if (job == null)
            {
                return BadRequest("Job not exists");
            }
            var perm = new PermissionVM(user, job.Dc, job.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return StatusCode(403, $"User not premitted to for application: {perm.App.Dc} - {perm.App.Application}");
            }
            _jobsService.DeleteJob(id);
            return Ok();
        }
    }
}

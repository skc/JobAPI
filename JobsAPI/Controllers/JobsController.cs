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
            if (job.ProgrammersNotes.Count > 0 || job.InfoNotes.Count > 0)
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
            if (job.OperatorsNotes.Count > 0 && !_permissionsService.IsOperator(user, _configuration))
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
    }
}

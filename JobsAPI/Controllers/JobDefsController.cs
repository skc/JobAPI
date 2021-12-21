using JobsAPI.Data.Services;
using JobsAPI.Data.ViewModel;
using JobsAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Controllers
{
    public class JobDefsController : ControllerBase
    {
        private JobDefsService _jobDefsService;
        private PermissionsService _permissionsService;
        private JobsService _jobsService;
        private IConfiguration _configuration;

        public JobDefsController(JobDefsService jobDefsService, PermissionsService permissionsService, JobsService jobsService, IConfiguration cofiguration)
        {
            _configuration = cofiguration;
            _jobDefsService = jobDefsService;
            _jobsService = jobsService;
            _permissionsService = permissionsService;
        }

        [HttpGet("get-jobdefs-by-application/{dc}/{application}")]
        public IActionResult GetJobDefsByApplication(string dc, string application)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, dc, application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return StatusCode(403, $"User not premitted for application: {dc} - {application}");
            }
            var jobDefs = _jobDefsService.GetJobDefsByApplication(dc, application);
            return Ok(_jobsService.GetJobIds(jobDefs));
        }
    }
}

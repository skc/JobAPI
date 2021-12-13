using JobsAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobsAPI.Data.ViewModel;

namespace JobsAPI.Controllers
{
    public class JobsController : ControllerBase
    {
        private JobsService _jobsService;
        public JobsController(JobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpPost("add-job")]
        public IActionResult AddJob([FromBody] JobVM jobVM)
        {

            return StatusCode((int)HttpStatusCode.Forbidden, "You can't jast do that");
        }
    }
}

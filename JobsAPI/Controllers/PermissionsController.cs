using JobsAPI.Data.Models;
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
    public class PermissionsController : ControllerBase
    {
        private PermissionsService _permissionsService;
        private IConfiguration _configuration;
        public PermissionsController(PermissionsService permissionsService, IConfiguration cofiguration)
        {
            _configuration = cofiguration;
            _permissionsService = permissionsService;
        }
        [HttpPost("add-permission")]
        public IActionResult AddPermission([FromBody] PermissionVM permission)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            if (_permissionsService.GetPermission(permission) != null)
            {
                return BadRequest("Permission already exists");
            }
            if (!_permissionsService.MayGrant(permission, _configuration))
            {
                return Forbid();
            }
            _permissionsService.AddPermission(permission, user);
            return Ok();
        }

        [HttpDelete("delete-permission-by-id/{id}")]
        public IActionResult DeletePermissionById(int id)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            Permission _permission = _permissionsService.GetPermissionById(id);
            if (_permission == null)
            {
                return BadRequest("Permission not exists");
            }
            if (!_permissionsService.MayGrant(_permission, _configuration))
            {
                return Forbid();
            }
            _permissionsService.DeletePermission(_permission);
            return Ok();
        }

        [HttpGet("get-permitted-applications")]
        public IActionResult GetPermittedApplication()
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var applications = _permissionsService.GetPermittedApplications(user);
            return Ok(applications);
        }

        [HttpGet("get-application-permissions/{dc}/{application}")]
        public IActionResult GetApplicationPermissions(string dc, string application)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, dc, application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return Forbid();
            }
            var permissions = _permissionsService.GetApplicationPermissions(perm.App);
            return Ok(permissions);
        }
    }
}

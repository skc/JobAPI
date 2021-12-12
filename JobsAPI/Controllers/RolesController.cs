using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPI.Data.Models.ViewModel;
using JobsAPI.Data.Models;
using JobsAPI.Data.Services;
using JobsAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using JobsAPI.Data.ViewModel;

namespace JobsAPI.Controllers
{
    public class RolesController : ControllerBase
    {
        private RolesService _rolesService;
        private PermissionsService _permissionsService;
        private IConfiguration _configuration;

        public RolesController(RolesService rolesService, PermissionsService permissionsService, IConfiguration cofiguration)
        {
            _configuration = cofiguration;
            _rolesService = rolesService;
            _permissionsService = permissionsService;
        }

        [HttpPost("add-role")]
        public IActionResult AddRole([FromBody] RoleVM role)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, role.Dc, role.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return Forbid();
            }
            _rolesService.AddRole(role, user);
            return Ok();
        }
        [HttpGet("get-roles-by-application/{dc}/{application}")]
        public IActionResult GetRolesByApplication(string dc, string application)
        {
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, dc, application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return Forbid();
            }
            var roles = _rolesService.GetRolesByApplication(perm.App);
            return Ok(roles);
        }
        [HttpPut("update-role-programmers")]
        public IActionResult UpdateRoleProgrammers([FromBody] RoleProgrammersVM roleProgrammers)
        {
            Role role = _rolesService.GetRoleById(roleProgrammers.RoleId);
            if (role == null)
                return BadRequest();
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, role.Dc, role.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return Forbid();
            }
            _rolesService.UpdateRoleProgrammers(role, roleProgrammers);
            return Ok();
        }
        [HttpDelete("delete-rule-by-id/{id}")]
        public IActionResult DeleteRoleById(int id)
        {
            Role role = _rolesService.GetRoleById(id);
            if (role == null)
                return BadRequest();
            var user = AccountHelper.GetAccountName(HttpContext);
            var perm = new PermissionVM(user, role.Dc, role.Application);
            if (!_permissionsService.IsPermittedForApplication(perm, _configuration))
            {
                return Forbid();
            }
            _rolesService.DeleteRole(role);
            return Ok();
        }
    }
}

using JobsAPI.Data.Models;
using JobsAPI.Data.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Services
{
    public class PermissionsService
    {
        private JobsDbContext _context;
        public PermissionsService(JobsDbContext context)
        {
            _context = context;
        }

        public Permission GetPermission(PermissionVM perm) =>
            _context.Permissions.FirstOrDefault(p =>
            p.User == perm.User && p.Dc == perm.App.Dc && p.Application == perm.App.Application);

        public Permission GetPermissionById(int id) =>
            _context.Permissions.FirstOrDefault(p => p.PermissionId == id);

        public bool IsAdministrator(string user, IConfiguration configuration) =>
            configuration.GetSection("JobsSettings:AdminUsers").Get<List<string>>().Contains(user);

        public bool IsOperator(string user, IConfiguration configuration) =>
            configuration.GetSection("JobsSettings:AdminUsers").Get<List<string>>().Contains(user) ||
            configuration.GetSection("JobsSettings:OperatorsUsers").Get<List<string>>().Contains(user);

        public bool IsPermittedForApplication(PermissionVM perm, IConfiguration configuration)
        {
            if (IsAdministrator(perm.User, configuration))
                return true;
            var permmision = GetPermission(perm);
            if (permmision != null)
                return true;
            return false;
        }

        public bool MayGrant(Permission perm, IConfiguration configuration) =>
            MayGrant(new PermissionVM(perm.User, perm.Dc, perm.Application), configuration);

        public bool MayGrant(PermissionVM perm, IConfiguration configuration)
        {
            if (IsAdministrator(perm.User, configuration) || IsOperator(perm.User, configuration))
                return true;
            var permmision = GetPermission(perm);
            return permmision != null && permmision.MayGrant;
        }

        public void AddPermission(PermissionVM permissionVM, string user)
        {
            var _permission = new Permission()
            {
                User = permissionVM.User,
                Dc = permissionVM.App.Dc,
                Application = permissionVM.App.Application,
                MayGrant = permissionVM.MayGrant,
                GrantedBy = user,
                GrantedAt = DateTime.Now
            };
            _context.Permissions.Add(_permission);
            _context.SaveChanges();
        }

        public void DeletePermission(Permission permission)
        {
            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }

        public List<Permission> GetApplicationPermissions(ApplicationVM app) =>
            _context.Permissions.Where(p => p.Dc == app.Dc && p.Application == app.Application).ToList();

        public List<ApplicationVM> GetPermittedApplications(string user) =>
            _context.Permissions
                .Where(p => p.User == user)
                .Select(p => new ApplicationVM() { Dc = p.Dc, Application = p.Application })
                .ToList();
    }
}

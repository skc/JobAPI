using JobsAPI.Data.Models;
using JobsAPI.Data.Models.ViewModel;
using JobsAPI.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data.Services
{
    public class RolesService
    {
        private JobsDbContext _context;
        public RolesService(JobsDbContext context)
        {
            _context = context;
        }
        public void AddRole(RoleVM roleVM, string user)
        {
            var _role = new Role()
            {
                Dc = roleVM.Dc,
                Application = roleVM.Application,
                Name = roleVM.Name,
                AddedAt = DateTime.Now,
                AddedBy = user
            };
            _context.Roles.Add(_role);
            _context.SaveChanges();
        }
        public void UpdateRoleProgrammers(Role role, RoleProgrammersVM roleProgrammersVM)
        {
            var role_progs = _context.Role_Programmers.Where(rp => rp.RoleId == roleProgrammersVM.RoleId).ToList<Role_Programmer>();
            _context.Role_Programmers.RemoveRange(role_progs);
            List<Role_Programmer> progs = roleProgrammersVM.ProgrammerIds.Select((id, order) => new Role_Programmer()
            {
                ProgarmmerId = id,
                Order = order,
                RoleId = roleProgrammersVM.RoleId
            }).ToList<Role_Programmer>();
            role.Role_Programmers = progs;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public Role GetRoleById(int Id) => _context.Roles.FirstOrDefault(r => r.RoleId == Id);

        public List<RoleProgrammersVM> GetRolesByApplication(ApplicationVM application) =>
            _context.Roles
                .Where(r => r.Dc == application.Dc && r.Application == application.Application)
                .Select(r => new RoleProgrammersVM()
                {
                    RoleId = r.RoleId,
                    Name = r.Name,
                    ProgrammerIds = _context.Role_Programmers
                        .Where(rp => rp.RoleId == r.RoleId)
                        .OrderBy(rp => rp.Order)
                        .Select(rp => rp.ProgarmmerId)
                        .ToList()
                })
                .ToList();

        public void DeleteRole(Role role)
        {
            var role_progs = _context.Role_Programmers.Where(rp => rp.RoleId == role.RoleId).ToList<Role_Programmer>();
            _context.Role_Programmers.RemoveRange(role_progs);
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}

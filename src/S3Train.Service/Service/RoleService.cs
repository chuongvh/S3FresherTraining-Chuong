using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using S3Train.Contract;
using S3Train.Core.Enum;
using S3Train.Domain;
using S3Train.Model.Role;
using X.PagedList;

namespace S3Train.Service
{
    public class RoleService : IRoleService
    {
        private readonly IAccountManager _accountManager;
        public RoleService(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public async Task<ApplicationRole> FindByIdAsync(string id)
        {
            return await _accountManager.RolesManager.FindByIdAsync(id);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _accountManager.RolesManager.RoleExistsAsync(roleName);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role)
        {
            if (string.IsNullOrEmpty(role.Id))
                role.Id = Guid.NewGuid().ToString();

            return await _accountManager.RolesManager.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role)
        {
            var result = await _accountManager.RolesManager.UpdateAsync(role);
            return result;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role)
        {
            return await _accountManager.RolesManager.DeleteAsync(role);
        }

        public async Task<IPagedList<RoleViewModel>> GetRolesAsync(int pageIndex, int pageSize)
        {
            return await _accountManager.Query<ApplicationRole>().Where(c => c.Name != DefaultRole.Administration)
                .OrderBy(order => order.Name)
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToPagedListAsync(pageIndex, pageSize);
        }

        public List<ApplicationRole> GetAllRoles()
        {
            return _accountManager.Query<ApplicationRole>().Where(c => c.Name != DefaultRole.Administration)
                .OrderBy(order => order.Name).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using S3Train.Domain;
using S3Train.Model.User;
using X.PagedList;

namespace S3Train.Contract
{
    public interface IUserService
    {
        Task<IList<string>> GetRolesForUser(string userId);
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> GetUserByUserName(string userName);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserByUserNameAndPassword(string userName, string password);
        Task<IdentityResult> UpdatePassword(string id, string password);
        Task<IdentityResult> Create(ApplicationUser user, string password);
        Task<IdentityResult> Update(ApplicationUser user);
        Task<IList<UserLoginInfo>> GetLogins(string id);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool shouldLockout = false);
        void SignOut();
        Task<string> GeneratePasswordResetToken(string userId);
        Task<IdentityResult> ConfirmEmail(string userId, string token);
        Task<IdentityResult> ResetPassword(string userId, string token, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string applicationType);
        Task<IdentityResult> UserAddToRoles(string userId, params string[] roles);
        Task<IdentityResult> RemoveFromRoles(string userId, params string[] roles);
        Task<IPagedList<UserViewModel>> GetUser(int pageIndex, int pageSize);
    }
}

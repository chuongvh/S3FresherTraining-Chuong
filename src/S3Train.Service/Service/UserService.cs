using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using S3Train.Contract;
using S3Train.Core.Enum;
using S3Train.Domain;
using S3Train.Model.User;
using X.PagedList;

namespace S3Train.Service
{
    public class UserService : IUserService
    {
        private readonly IAccountManager _accountManager;
        private readonly IUserIdentityService _userIdentityService;
        public UserService(IAccountManager accountManager, IUserIdentityService userIdentityService)
        {
            _accountManager = accountManager;
            _userIdentityService = userIdentityService;
        }

        public async Task<IList<string>> GetRolesForUser(string userId)
        {
            return await _accountManager.UserManager.GetRolesAsync(userId);
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _accountManager.UserManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return await _accountManager.UserManager.FindByNameAsync(userName);
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _accountManager.UserManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByUserNameAndPassword(string userName, string password)
        {
            return await _accountManager.UserManager.FindAsync(userName, password);
        }

        public async Task<IdentityResult> UpdatePassword(string id, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return IdentityResult.Failed(new ArgumentNullException(password).ToString());
            }

            var userInfor = await _accountManager.UserManager.FindByIdAsync(id);
            if (userInfor == null)
            {
                return IdentityResult.Failed(new Exception("User does not found").ToString());
            }

            var removePassword = await _accountManager.UserManager.RemovePasswordAsync(id);
            if (!removePassword.Succeeded)
            {
                return IdentityResult.Failed(new Exception("Remove password fail").ToString());
            }

            var userChangePassword = await _accountManager.UserManager.AddPasswordAsync(id, password);
            return userChangePassword;
        }

        public async Task<IdentityResult> Create(ApplicationUser user, string password)
        {
            if (string.IsNullOrEmpty(user.Id))
                user.Id = Guid.NewGuid().ToString();

            var result = await _accountManager.UserManager.CreateAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> Update(ApplicationUser user)
        {
            var result = await _accountManager.UserManager.UpdateAsync(user);
            return result;
        }

        public async Task<IList<UserLoginInfo>> GetLogins(string id)
        {
            var user = await _accountManager.UserManager.FindByIdAsync(id);
            if (user == null)
                return new List<UserLoginInfo>();

            return await _accountManager.UserManager.GetLoginsAsync(id);
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent, bool shouldLockout = false)
        {
            ClaimsIdentity identity = await _accountManager.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            var claims = _userIdentityService.ConvertApplicationUserToClaims(user);
            identity.AddClaims(claims);

            _accountManager.AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = isPersistent
            }, identity);
        }

        public void SignOut()
        {
            _accountManager.AuthenticationManager.SignOut();
        }

        public async Task<string> GeneratePasswordResetToken(string userId)
        {
            return await _accountManager.UserManager.GeneratePasswordResetTokenAsync(userId);
        }

        public async Task<IdentityResult> ConfirmEmail(string userId, string token)
        {
            return await _accountManager.UserManager.ConfirmEmailAsync(userId, token);
        }

        public async Task<IdentityResult> ResetPassword(string userId, string token, string password)
        {
            return await _accountManager.UserManager.ResetPasswordAsync(userId, token, password);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            return await _accountManager.UserManager.GenerateEmailConfirmationTokenAsync(userId);
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string applicationType)
        {
            return _accountManager.UserManager.CreateIdentityAsync(user, applicationType);
        }

        public async Task<IdentityResult> UserAddToRoles(string userId, params string[] roles)
        {
            if (userId == string.Empty)
                return null;

            var result = await _accountManager.UserManager.AddToRolesAsync(userId, roles);
            return result;
        }

        public async Task<IdentityResult> RemoveFromRoles(string userId, params string[] roles)
        {
            if (userId == string.Empty)
                return null;

            var result = await _accountManager.UserManager.RemoveFromRolesAsync(userId, roles);
            return result;
        }

        public async Task<IPagedList<UserViewModel>> GetUser(int pageIndex, int pageSize)
        {
            return await _accountManager.UserManager.Users.Where(c => c.UserName != DefaultUser.Administration)
                .OrderByDescending(order => order.Email)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FullName = u.FullName,
                    Avatar = u.Avatar,
                    PhoneNumber = u.PhoneNumber,
                }).ToPagedListAsync(pageIndex, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using S3Train.Contract;
using S3Train.Core.Constant;
using S3Train.Domain;

namespace S3Train.Service
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IOwinContext _owinContext;
        private readonly IRoleService _roleService;

        public UserIdentityService(IOwinContext owinContext,
                                    IRoleService roleService)
        {
            _owinContext = owinContext;
            _roleService = roleService;
        }

        public IAuthenticationManager Authentication
        {
            get { return _owinContext.Authentication; }
        }

        public IPrincipal Principal
        {
            get { return Authentication != null ? Authentication.User : null; }
        }

        public IIdentity Identity
        {
            get
            {
                if (Principal == null)
                    return null;

                return Principal.Identity;
            }
        }

        public string GetUserName()
        {
            IIdentity identity = Identity;
            if (identity == null)
                return string.Empty;

            return Principal.Identity.Name;
        }

        public bool IsRoleInUser(string roleName)
        {
            IPrincipal principal = Principal;
            if (principal == null)
                return false;
            return principal.IsInRole(roleName);
        }

        public bool IsAuthentication
        {
            get
            {
                if (Identity == null)
                    return false;
                return Identity.IsAuthenticated;
            }
        }

        public ApplicationUser ConvertClaimsPrincipalToApplicationUser()
        {
            if (!IsAuthentication)
                return null;

            var prinicpal = (ClaimsPrincipal)Principal;

            var claims = prinicpal.Claims.ToList();

            var applicalicationUser = new ApplicationUser
            {
                UserName = GetUserName()
            };

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (email != null)
                applicalicationUser.Email = email.Value;

            var fullName = claims.FirstOrDefault(c => c.Type == ClaimTypesCustom.FullName);
            if (fullName != null)
                applicalicationUser.FullName = fullName.Value;

            var avatar = claims.FirstOrDefault(c => c.Type == ClaimTypesCustom.Avatar);
            if (avatar != null)
                applicalicationUser.Avatar = avatar.Value;

            return applicalicationUser;
        }

        public IEnumerable<Claim> ConvertApplicationUserToClaims(ApplicationUser applicationUser)
        {
            List<Claim> identity = new List<Claim>();

            if (!string.IsNullOrEmpty(applicationUser.Email))
                identity.Add(new Claim(ClaimTypes.Email, applicationUser.Email));

            if (!string.IsNullOrEmpty(applicationUser.FullName))
                identity.Add(new Claim(ClaimTypesCustom.FullName, applicationUser.FullName));

            if (!string.IsNullOrEmpty(applicationUser.Avatar))
                identity.Add(new Claim(ClaimTypesCustom.Avatar, applicationUser.Avatar));

            return identity;
        }

        public IEnumerable<string> GetRoles()
        {
            if (!IsAuthentication)
                return null;

            var prinicpal = (ClaimsPrincipal)Principal;

            return prinicpal.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(s => s.Value);
        }
    }
}

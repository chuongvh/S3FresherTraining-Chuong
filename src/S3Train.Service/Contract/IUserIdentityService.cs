using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Owin.Security;
using S3Train.Domain;

namespace S3Train.Contract
{
    public interface IUserIdentityService
    {
        IAuthenticationManager Authentication { get; }
        IPrincipal Principal { get; }
        IIdentity Identity { get; }
        string GetUserName();
        bool IsRoleInUser(string roleName);
        bool IsAuthentication { get; }
        ApplicationUser ConvertClaimsPrincipalToApplicationUser();
        IEnumerable<Claim> ConvertApplicationUserToClaims(ApplicationUser applicationUser);
        IEnumerable<string> GetRoles();
    }
}

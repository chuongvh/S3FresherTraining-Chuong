using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace MVC.Core.Extension.Helper
{
    /// <summary>
    /// Helper class to get user identity information
    /// </summary>
    public static class UserIdentityHelper
    {
        #region Get
        
        public static string InternalUserId => GetCurrentUserClaim(ClaimTypes.NameIdentifier) ?? string.Empty;

        /// <summary>
        /// Gets the current user in http context
        /// </summary>
        /// <returns></returns>
        public static ClaimsIdentity CurrentUser
        {
            get
            {
                return Thread.CurrentPrincipal?.Identity as ClaimsIdentity;
            }
        }

        /// <summary>
        /// Gets the current user claim property
        /// </summary>
        /// <param name="claimType">type of the claim</param>
        /// <returns></returns>
        public static string GetCurrentUserClaim(string claimType)
        {
            var currentUser = CurrentUser;
            if (currentUser == null)
            {
                return null;
            }
            var claim = currentUser.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }

        #endregion

        #region Set

        /// <summary>
        /// Sets the current user principal to thread.
        /// </summary>
        /// <param name="userPrincipal">The user principal.</param>
        public static void SetCurrentUserPrincipalToThread(ClaimsPrincipal userPrincipal)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new ClaimsIdentity(userPrincipal.Claims), null
            );
        }
        
        /// <summary>
        /// Adds more claim to current Principal (identity by claim type)
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public static void AddClaim(string type, string value)
        {
            if(value.IsNullOrEmpty())
                return;

            var currentUser = CurrentUser;
            if (currentUser == null)
                return;

            currentUser.AddClaim(new Claim(type, value));
        }

        #endregion
    }
}

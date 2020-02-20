using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.IdentityManager;

namespace S3Train.Service
{
    public class AccountManager : ApplicationDbContext, IAccountManager
    {
        private readonly IOwinContext _owinContext;
        public AccountManager(IOwinContext owinContext)
        {
            _owinContext = owinContext;
        }

        public ApplicationUserManager UserManager => _owinContext.Get<ApplicationUserManager>();

        public ApplicationRoleManager RolesManager => _owinContext.Get<ApplicationRoleManager>();

        public IAuthenticationManager AuthenticationManager => _owinContext.Authentication;

        public ApplicationSignInManager SignInManager => _owinContext.Get<ApplicationSignInManager>();

        public ApplicationUserStoreManager UserStoreManager => _owinContext.Get<ApplicationUserStoreManager>();

        public ApplicationRoleStoreManager RoleStoreManager => _owinContext.Get<ApplicationRoleStoreManager>();

        public IQueryable<ApplicationUser> GetQueryableUser => Users;

        public IQueryable<ApplicationRole> GetQueryableRole => Roles;

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}

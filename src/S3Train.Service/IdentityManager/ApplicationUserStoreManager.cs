using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using S3Train.Domain;

namespace S3Train.IdentityManager
{
    public class ApplicationUserStoreManager : UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStoreManager(DbContext context) : base(context)
        {

        }

        public static ApplicationUserStoreManager Create(IdentityFactoryOptions<ApplicationUserStoreManager> userStoreManager, IOwinContext owinContext)
        {
            return new ApplicationUserStoreManager(owinContext.Get<ApplicationDbContext>());
        }
    }
}

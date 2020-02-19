using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using S3Train.Domain;

namespace S3Train.IdentityManager
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, string>
    {
        public ApplicationRoleManager(ApplicationRoleStoreManager store) : base(store)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> applicationRoleManager, IOwinContext context)
        {
            var userStore = context.Get<ApplicationRoleStoreManager>();

            return new ApplicationRoleManager(userStore);
        }
    }
}

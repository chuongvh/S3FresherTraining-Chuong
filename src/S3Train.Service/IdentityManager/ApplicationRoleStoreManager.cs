using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using S3Train.Domain;

namespace S3Train.IdentityManager
{
    public class ApplicationRoleStoreManager : RoleStore<ApplicationRole, string, ApplicationUserRole>
    {
        public ApplicationRoleStoreManager(DbContext context) : base(context)
        {

        }

        public static ApplicationRoleStoreManager Create(IdentityFactoryOptions<ApplicationRoleStoreManager> roleStoreManager, IOwinContext context)
        {
            return new ApplicationRoleStoreManager(context.Get<ApplicationDbContext>());
        }
    }
}

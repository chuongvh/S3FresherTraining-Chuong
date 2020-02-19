using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using S3Train.Service;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Owin;
using S3Train.Contract;
using S3Train.Domain;

namespace S3Train.App_Start
{
    public static class DependencyConfig
    {
        public static IContainer RegisterDependencyResolvers()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterContext(builder);
            RegisterDependencyMappingDefaults(builder);
            RegisterDependencyMappingOverrides(builder);
            IContainer container = builder.Build();
            // Set Up MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Set Up WebAPI Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }

        private static void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.Register(ctx =>
                {
                    HttpContextBase httpContext = ctx.Resolve<HttpContextBase>();
                    if (httpContext != null)
                    {
                        return httpContext.GetOwinContext();
                    }
                    return HttpContext.Current.GetOwinContext();
                }).As<IOwinContext>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterDependencyMappingDefaults(ContainerBuilder builder)
        {
            Assembly coreAssembly = Assembly.GetAssembly(typeof(IStateManager));
            Assembly webAssembly = Assembly.GetAssembly(typeof(MvcApplication));

            builder.RegisterAssemblyTypes(coreAssembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(webAssembly);
            builder.RegisterModule(new AutofacWebTypesModule());
        }

        private static void RegisterDependencyMappingOverrides(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<AccountManager>().As<IAccountManager>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserIdentityService>().As<IUserIdentityService>();
            builder.RegisterType<ProductService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ProductAdvertisementService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
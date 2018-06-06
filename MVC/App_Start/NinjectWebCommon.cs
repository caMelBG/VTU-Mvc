[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVC.App_Start.NinjectWebCommon), "Stop")]

namespace MVC.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using DataBase;
    using DataBase.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repositories;
    using Repositories.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<UniversityContext>()
                .InTransientScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>()
                .InTransientScope();

            kernel.Bind<IRepository<User>>().To<Repository<User>>()
                .InTransientScope();

            kernel.Bind<RoleStore<IdentityRole>>().To<RoleStore<IdentityRole>>()
                .InTransientScope();

            kernel.Bind<RoleManager<IdentityRole>>().To<RoleManager<IdentityRole>>()
                .InTransientScope()
                .WithConstructorArgument("store", kernel.Get<RoleStore<IdentityRole>>());
        }
    }
}

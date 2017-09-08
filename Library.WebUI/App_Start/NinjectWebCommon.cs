[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Library.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Library.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace Library.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Domain.Abstracts;
    using Domain.Concrete;
    using Domain.Entities;
    using Domain.Helper.DataRequired.MongoDbDataRequired;
    using Domain.Helper;
    using Domain.Concrete.DataRequiredConcrete;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static bool DefaultConnection = true;
        
        public static void InitConnection(string conString)
        {
            if (conString == "DefaultConnection")
            {
                DefaultConnection = true;
                Stop();
                Start();
            }
            else
            {
                DefaultConnection = false;
                Stop();
                Start();
            }
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
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
            if (DefaultConnection)
            {
                kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
                kernel.Bind<IBookRepository>().To<BookRepository>();
                kernel.Bind<IConvertDataHelper<AuthorMsSql, Author>>().To<MssqlAuthorConvert>();
                kernel.Bind<IConvertDataHelper<BookMsSql, Book>>().To<MssqlBookDataConvert>();
                kernel.Bind<IDataRequired<Book>>().To<BookDataRequiredMS>();
            }
            else
            {
                kernel.Bind<IAuthorRepository>().To<AuthorMongoDbRepository>();
                kernel.Bind<IBookRepository>().To<BookMongoDbRepository>();
                kernel.Bind<IConvertDataHelper<AuthorMongoDb, Author>>().To<MongoDbAuthorDataConvert>();
                kernel.Bind<IConvertDataHelper<BookMongoDb, Book>>().To<MongoDbBookDataConvert>();
                kernel.Bind<IDataRequired<Book>>().To<BookDataRequiredMDB>();
            }
            kernel.Bind<IDataRequired<Author>>().To<AuthorDataRequired>();
        }        
    }
}

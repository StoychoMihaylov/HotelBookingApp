[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HotelBooking.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HotelBooking.App.App_Start.NinjectWebCommon), "Stop")]


namespace HotelBooking.App.App_Start
{
    using HotelBooking.Data;
    using HotelBooking.Data.Interfaces;
    using HotelBooking.Services;
    using HotelBooking.Services.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(Ninject.Web.Common.WebHost.NinjectHttpModule));
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
            kernel.Bind<IHotelBookingDbContext>().To<HotelBookingDbContext>();
            kernel.Bind<IReviewServices>().To<ReviewService>();
            kernel.Bind<IBookingService>().To<BookingService>();
            kernel.Bind<IAdminService>().To<AdminService>();
        }
    }
}

// You can remove the reference to WebActivator by calling the Start() method from your Global.asax Application_Start
[assembly: WebActivator.PreApplicationStartMethod(typeof(DownloadStreamRecipe.App_Start.AppStartFubuMVC), "Start", callAfterGlobalAppStart: true)]

namespace DownloadStreamRecipe.App_Start
{
    using System.Web.Routing;
    using Bottles;
    using FubuMVC.Core;
    using FubuMVC.StructureMap;
    using StructureMap;

    public static class AppStartFubuMVC
    {
        public static void Start()
        {
            // FubuApplication "guides" the bootstrapping of the FubuMVC
            // application
            FubuApplication.For<ConfigureFubuMVC>() // ConfigureFubuMVC is the main FubuRegistry
                                                    // for this application.  FubuRegistry classes 
                                                    // are used to register conventions, policies,
                                                    // and various other parts of a FubuMVC application


                // FubuMVC requires an IoC container for its own internals.
                // In this case, we're using a brand new StructureMap container,
                // but FubuMVC just adds configuration to an IoC container so
                // that you can use the native registration API's for your
                // IoC container for the rest of your application
                .StructureMap(new Container())
                .Bootstrap();

			// Ensure that no errors occurred during bootstrapping
			PackageRegistry.AssertNoFailures();
        }
    }
}
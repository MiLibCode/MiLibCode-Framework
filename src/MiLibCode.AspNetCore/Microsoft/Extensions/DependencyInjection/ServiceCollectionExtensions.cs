using ExtCore.WebApplication;
using ExtCore.WebApplication.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Contains the extension methods of the <see cref="IServiceCollection">IServiceCollection</see> interface.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Discovers the assemblies and executes the ConfigureServices actions from all the extensions.
        /// It must be called inside the ConfigureServices method of the web application's Startup class
        /// in order ExtCore to work properly.
        /// </summary>
        /// <param name="services">
        /// The services collection passed to the ConfigureServices method of the web application's Startup class.
        /// </param>
        public static void AddModuleCore(this IServiceCollection services)
        {
            services.AddModuleCore(null);
        }

        /// <summary>
        /// Discovers the assemblies and executes the ConfigureServices actions from all the extensions.
        /// It must be called inside the ConfigureServices method of the web application's Startup class
        /// in order ExtCore to work properly.
        /// </summary>
        /// <param name="services">
        /// The services collection passed to the ConfigureServices method of the web application's Startup class.
        /// </param>
        /// <param name="extensionsPath">The absolute extensions path.</param>
        public static void AddModuleCore(this IServiceCollection services, string extensionsPath)
        {
            services.AddModuleCore(extensionsPath, false);
        }

        /// <summary>
        /// Discovers the assemblies and executes the ConfigureServices actions from all the extensions.
        /// It must be called inside the ConfigureServices method of the web application's Startup class
        /// in order ExtCore to work properly.
        /// </summary>
        /// <param name="services">
        /// The services collection passed to the ConfigureServices method of the web application's Startup class.
        /// </param>
        /// <param name="extensionsPath">The absolute extensions path.</param>
        /// <param name="includingSubpaths">Determines whether the assemblies must be loaded from the subfolders recursively.</param>
        public static void AddModuleCore(this IServiceCollection services, string extensionsPath, bool includingSubpaths)
        {
            services.AddModuleCore(extensionsPath, includingSubpaths, new DefaultAssemblyProvider(services.BuildServiceProvider()));
        }

        /// <summary>
        /// Discovers the assemblies and executes the ConfigureServices actions from all the extensions.
        /// It must be called inside the ConfigureServices method of the web application's Startup class
        /// in order ExtCore to work properly.
        /// </summary>
        /// <param name="services">
        /// The services collection passed to the ConfigureServices method of the web application's Startup class.
        /// </param>
        /// <param name="extensionsPath">The absolute extensions path.</param>
        /// <param name="includingSubpaths">Determines whether the assemblies must be loaded from the subfolders recursively.</param>
        /// <param name="assemblyProvider">The assembly provider that is used to discover and load the assemblies.</param>
        public static void AddModuleCore(this IServiceCollection services, string extensionsPath, bool includingSubpaths, IAssemblyProvider assemblyProvider)
        {
            services.AddExtCore(extensionsPath, includingSubpaths, assemblyProvider);
        }
    }
}

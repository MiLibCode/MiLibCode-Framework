using ExtCore.WebApplication.Extensions;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Contains the extension methods of the <see cref="IApplicationBuilder">IApplicationBuilder</see> interface.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Executes the Configure actions from all the extensions. It must be called inside the Configure method
        /// of the web application's Startup class in order ExtCore to work properly.
        /// </summary>
        /// <param name="applicationBuilder">
        /// The application builder passed to the Configure method of the web application's Startup class.
        /// </param>
        public static void UseModuleCore(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExtCore();
        }
    }
}

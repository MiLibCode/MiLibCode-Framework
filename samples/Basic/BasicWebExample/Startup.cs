using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiLibCode;

namespace BasicWebExample
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        private string _extensionsPath;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

            if (!string.IsNullOrEmpty(_configuration["Modules:Path"]))
                this._extensionsPath = _hostingEnvironment.ContentRootPath + _configuration["Modules:Path"];
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModuleCore(_extensionsPath);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseModuleCore();

            app.Run(async (context) =>
            {
                //var module = ModuleManager.GetInstance<IModule>();
                //await context.Response.WriteAsync($"Module Name: {module?.Name ?? "N/A"} {System.Environment.NewLine} Authors: {module?.Authors}");
                var modules = ModuleManager.GetInstances<IModule>();
                foreach (var module in modules)
                {
                    await context.Response.WriteAsync($"Module Name: {module?.Name ?? "N/A"} --- Authors: {module?.Authors}");//{System.Environment.NewLine}
                    await context.Response.WriteAsync(System.Environment.NewLine);
                }
                //await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

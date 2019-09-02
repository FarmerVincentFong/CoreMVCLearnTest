using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMVCControllerTest1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //引入mvc模块
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //配置路由
            app.UseMvc(routes =>
            {
                //ParamsMappingTest专用路由
                routes.MapRoute(name: "ParamsMappingTest", template: "pmt/{action}/{id?}", defaults: new { controller = "ParamsMappingTest" });

                //TestActionResultController专用路由
                routes.MapRoute(name: "TestActionResult", template: "tar/{action}", defaults: new { controller = "TestActionResult" });

                routes.MapRoute(name: "Default", template: "{controller}/{action}/{id?}"
                    , defaults: new { controller = "Home", action = "Index" }, constraints: new { });
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationEFCoreLocalTest1.Repositories;
using WebApplicationEFCoreLocalTest1.Middlewares;
using WebApplicationEFCoreLocalTest1.DIServices;

namespace WebApplicationEFCoreLocalTest1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //配置DbContext注入
            services.AddTransient<CusDbContext>();
            //配置Repository注入
            services.AddTransient<UserRepository>();
            services.AddTransient<UserWithSqlRepository>();
            #region 测试依赖注入及其生命周期
            // 默认构造
            services.AddSingleton<ITestOperationSingleton, TestOperation>();
            //自定义传入Guid空值
            services.AddSingleton<ITestOperationSingleton>(new TestOperation());
            // 自定义传入一个New的Guid
            services.AddSingleton<ITestOperationSingleton>(new TestOperation(Guid.Empty));
            //Transient服务
            services.AddTransient<ITestOperationTransient, TestOperation>();
            //Scoped服务
            services.AddScoped<ITestOperationScoped, TestOperation>();
            //通过privider创建服务实例
            var provider = services.BuildServiceProvider();
            var testSingle1 = provider.GetService<ITestOperationSingleton>();
            var testSingle2 = provider.GetService<ITestOperationSingleton>();
            var testSingle3 = provider.GetService<ITestOperationSingleton>();
            var testTransient1 = provider.GetService<ITestOperationTransient>();
            var testTransient2 = provider.GetService<ITestOperationTransient>();
            var testTransient3 = provider.GetService<ITestOperationTransient>();
            var testScoped1 = provider.GetService<ITestOperationScoped>();
            var testScoped2 = provider.GetService<ITestOperationScoped>();
            using (var scope2 = provider.CreateScope())
            {
                var provider2 = scope2.ServiceProvider;
                var testScoped3 = provider2.GetService<ITestOperationScoped>();
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            //使用验签中间件
            //app.UseTokenCheck();
            //app.UseMiddleware<TokenCheckMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplicationEFCoreLocalTest1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>().ConfigureLogging(logging =>
                 {
                     //配置内置日志组件
                     logging.ClearProviders();
                     logging.SetMinimumLevel(LogLevel.Information);
                     logging.AddConsole();
                 });
        }
    }
}

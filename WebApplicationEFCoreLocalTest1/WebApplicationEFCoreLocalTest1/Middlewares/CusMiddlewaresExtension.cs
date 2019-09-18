using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEFCoreLocalTest1.Middlewares
{
    /// <summary>
    /// 注册中间件的扩展方法
    /// </summary>
    public static class CusMiddlewaresExtension
    {
        public static IApplicationBuilder UseTokenCheck(this IApplicationBuilder appBuild)
        {
            return appBuild.UseMiddleware<TokenCheckMiddleware>();
        }
    }
}

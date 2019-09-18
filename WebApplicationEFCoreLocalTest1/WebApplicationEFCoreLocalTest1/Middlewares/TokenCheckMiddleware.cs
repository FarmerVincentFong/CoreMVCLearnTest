using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEFCoreLocalTest1.Middlewares
{
    /// <summary>
    /// 请求验签中间件
    /// </summary>
    public class TokenCheckMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenCheckMiddleware(RequestDelegate rd)
        {
            //应该是 依赖注入这个委托对象
            this._next = rd;
        }
        public Task Invoke(HttpContext context)
        {
            //这里处理请求
            //先从Url取token，如果取不到就从Form表单中取token
            string token = context.Request.Query["token"].ToString() ?? context.Request.Form["token"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                //如果没有获取到token信息，那么就直接返回token missing响应
                return context.Response.WriteAsync("token missing By FWQ");
            }
            //获取前1分钟和当前的分钟
            var minute0 = DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm");
            var minute = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //当token和前一分钟或当前分钟任一时间字符串的MD5哈希一致，就认为是合法请求
            if (token == MD5Hash(minute0) || token == MD5Hash(minute))
            {
                //交给下一个中间件处理
                return _next.Invoke(context);
            }
            //如果token未验证通过返回token error
            return context.Response.WriteAsync("token error");
        }

        //获取字符串的MD5哈希
        public string MD5Hash(string text)
        {
            var md5 = MD5.Create();
            using (md5)
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
                return BitConverter.ToString(result).Replace("-", "");
            }
        }
    }
}

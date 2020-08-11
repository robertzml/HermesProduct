using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace HermesProduct.Middlewares
{
    using HermesProduct.Base.System;
    using HermesProduct.Models;
    using HermesProduct.Utility;

    /// <summary>
    /// JWT 认证中间件
    /// </summary>
    public class JwtMiddleware
    {
        #region Field
        private readonly RequestDelegate _next;
        #endregion //Field

        #region Constructor
        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            this._next = requestDelegate;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 认证失败返回
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <returns></returns>
        private string authFailed(string message)
        {
            var responseData = RestHelper<string>.MakeResponse(null, (int)ErrorCode.AuthorizationFailed, message);

            var serializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var strResult = JsonSerializer.Serialize(responseData, serializeOptions);

            return strResult;
        }
        #endregion //Function

        #region Method
        public async Task InvokeAsync(HttpContext context)
        {
            if (Regex.IsMatch(context.Request.Path.Value, "/api/health/.+"))
            {
                await _next(context);
                return;
            }

            if (context.Request.Headers["Authorization"].Count == 0)
            {
                await context.Response.WriteAsync(authFailed("need Authorization header"));
                return;
            }
            await _next(context);
        }
        #endregion //Method
    }
}

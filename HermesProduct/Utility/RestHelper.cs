using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HermesProduct.Utility
{
    using HermesProduct.Base.System;
    using HermesProduct.Models;

    public class RestHelper<T>
    {
        #region Method
        /// <summary>
        /// 生成返回结果
        /// </summary>
        /// <param name="result">实体数据</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ResponseData<T> MakeResponse(T result, int errorCode, string message)
        {
            ResponseData<T> data = new ResponseData<T>();
            data.Result = result;
            data.ErrorCode = errorCode;
            data.Message = message;
            data.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");

            try
            {
                IPHostEntry myEntry = Dns.GetHostEntry(Dns.GetHostName());
                var ip = myEntry.AddressList.FirstOrDefault<IPAddress>(e => e.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(e));

                data.IpAddress = ip.ToString();
            }
            catch (Exception)
            {
                data.IpAddress = "unknown";
            }

            return data;
        }

        /// <summary>
        /// 生成返回结果
        /// </summary>
        /// <param name="result">实体数据</param>
        /// <param name="errorCode">错误码</param>
        /// <returns></returns>
        public static ResponseData<T> MakeResponse(T result, ErrorCode errorCode)
        {
            ResponseData<T> data = new ResponseData<T>();
            data.Result = result;
            data.ErrorCode = (int)errorCode;
            data.Message = errorCode.DisplayName();
            data.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"); ;

            try
            {
                IPHostEntry myEntry = Dns.GetHostEntry(Dns.GetHostName());
                var ip = myEntry.AddressList.FirstOrDefault<IPAddress>(e => e.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(e));

                data.IpAddress = ip.ToString();
            }
            catch (Exception)
            {
                data.IpAddress = "unknown";
            }

            return data;
        }
        #endregion //Method
    }
}

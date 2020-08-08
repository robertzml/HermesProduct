using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HermesProduct.Base.System
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Display(Name = "成功")]
        Success = 0,

        /// <summary>
        /// 错误
        /// </summary>
        [Display(Name = "错误")]
        Error = 1,

        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Exception = 2,

        /// <summary>
        /// 未实现
        /// </summary>
        [Display(Name = "未实现")]
        NotImplement = 3,

        /// <summary>
        /// 对象已删除
        /// </summary>
        [Display(Name = "对象已删除")]
        ObjectDeleted = 4,

        /// <summary>
        /// 对象未找到
        /// </summary>
        [Display(Name = "对象未找到")]
        ObjectNotFound = 5,

        /// <summary>
        /// 数据库错误
        /// </summary>
        [Display(Name = "数据库错误")]
        DatabaseFailed = 6,

        /// <summary>
        /// 网络错误
        /// </summary>
        [Display(Name = "网络错误")]
        NetworkError = 7,

        /// <summary>
        /// 需要认证
        /// </summary>
        [Display(Name = "需要认证")]
        NeedAuthorization = 8,

        /// <summary>
        /// 认证失败
        /// </summary>
        [Display(Name = "认证失败")]
        AuthorizationFailed = 9,

        /// <summary>
        /// 认证超时
        /// </summary>
        [Display(Name = "认证超时")]
        AuthorizationExpire = 10
    }
}

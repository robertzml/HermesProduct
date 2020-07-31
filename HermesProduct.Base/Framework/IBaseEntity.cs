using System;
using System.Collections.Generic;
using System.Text;

namespace HermesProduct.Base.Framework
{
    /// <summary>
    /// 基础对象接口
    /// </summary>
    /// <typeparam name="Tkey">主键</typeparam>
    public interface IBaseEntity<Tkey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        Tkey Id { get; set; }
    }
}

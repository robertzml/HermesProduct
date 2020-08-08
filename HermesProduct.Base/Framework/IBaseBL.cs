using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Base.Framework
{
    using HermesProduct.Base.System;

    /// <summary>
    /// 基础业务接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IBaseBL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        Task<List<T>> FindAll();
    }
}

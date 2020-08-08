using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Services
{
    using HermesProduct.Base.System;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品类别接口
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// 获取所有产品类别
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> FindAll();

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity">产品类别</param>
        /// <returns></returns>
        Task<(ErrorCode errorCode, string errorMessage, Category t)> Create(Category entity);
    }
}

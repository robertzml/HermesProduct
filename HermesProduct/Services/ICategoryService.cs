using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Services
{
    using HermesProduct.Base.Framework;
    using HermesProduct.Base.System;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品类别接口
    /// </summary>
    public interface ICategoryService : IBaseBL<Category, string>
    {
        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity">产品类别</param>
        /// <returns></returns>
        Task<(ErrorCode errorCode, string errorMessage, Category t)> Create(Category entity);

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<(ErrorCode errorCode, string errorMessage)> Update(Category entity);
    }
}

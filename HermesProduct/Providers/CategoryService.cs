using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Providers
{
    using HermesProduct.Base.System;
    using HermesProduct.Core.BL;
    using HermesProduct.Core.Entity;
    using HermesProduct.Services;

    /// <summary>
    /// 产品类别业务类
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Field

        #endregion //Field        

        #region Method
        /// <summary>
        /// 获取所有产品类别
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> FindAll()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            return await categoryBusiness.FindAll();
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity">产品类别</param>
        /// <returns></returns>
        public async Task<(ErrorCode errorCode, string errorMessage, Category t)> Create(Category entity)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return await categoryBusiness.Create(entity);
        }
        #endregion //Method
    }
}

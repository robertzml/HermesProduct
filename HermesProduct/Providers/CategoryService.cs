using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Providers
{
    using HermesProduct.Base.System;
    using HermesProduct.Core.DL;
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
        public Task<List<Category>> FindAll()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.FindAll();
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity">产品类别</param>
        /// <returns></returns>
        public Task<(ErrorCode errorCode, string errorMessage, Category t)> Create(Category entity)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.Create(entity);
        }

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<(ErrorCode errorCode, string errorMessage)> Update(Category entity)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.Update(entity);
        }
        #endregion //Method
    }
}

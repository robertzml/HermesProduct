using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HermesProduct.Controllers
{
    using HermesProduct.Base.System;
    using HermesProduct.Core.Entity;
    using HermesProduct.Services;
    using HermesProduct.Models;
    using HermesProduct.Utility;

    /// <summary>
    /// 产品类别控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Field
        private ICategoryService categoryService;
        #endregion //Field

        #region Constructor
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取所有产品类别
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData<List<Category>>>> FindAll()
        {
            var data = await this.categoryService.FindAll();

            return RestHelper<List<Category>>.MakeResponse(data, ErrorCode.Success);
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="category">产品类别</param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData<Category>>> Create(Category category)
        {
            var result = await this.categoryService.Create(category);

            return RestHelper<Category>.MakeResponse(result.t, (int)result.errorCode, result.errorMessage);
        }
        #endregion //Action
    }
}

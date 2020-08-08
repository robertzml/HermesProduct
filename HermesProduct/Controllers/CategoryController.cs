using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HermesProduct.Controllers
{
    using HermesProduct.Base.System;
    using HermesProduct.Core.Facade;
    using HermesProduct.Core.BL;
    using HermesProduct.Core.Entity;
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
        /// <summary>
        /// 产品业务接口
        /// </summary>
        private ICategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            this.categoryBusiness = categoryBusiness;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取所有产品类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Category>>>> FindAll()
        {
            var data = await this.categoryBusiness.FindAll();

            return RestHelper<List<Category>>.MakeResponse(data, ErrorCode.Success);
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="category">产品类别</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<Category>>> Create(Category category)
        {
            var (errorCode, errorMessage, t) = await this.categoryBusiness.Create(category);

            return RestHelper<Category>.MakeResponse(t, (int)errorCode, errorMessage);
        }

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="category">产品类别</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<Category>>> Update(Category category)
        {
            var result = await this.categoryBusiness.Update(category);

            return RestHelper<Category>.MakeResponse(null, (int)result.errorCode, result.errorMessage);
        }
        #endregion //Action
    }
}

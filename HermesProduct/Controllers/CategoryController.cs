using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HermesProduct.Core.Entity;
using HermesProduct.Services;
using HermesProduct.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HermesProduct.Controllers
{
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
        public async Task<ActionResult<List<Category>>> FindAll()
        {
            return await this.categoryService.FindAll();
        }

        public ActionResult<ResponseData> Create(Category category)
        {
            var result = this.categoryService.Create(category);

            ResponseData rd = new ResponseData
            {
                ErrorMessage = result.errorMessage,
                Status = result.success ? 0 : 1,
                Entity = result.t
            };

            return rd;
        }
        #endregion //Action
    }
}

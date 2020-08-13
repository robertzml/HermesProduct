using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HermesProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 服务状态检查
        /// </summary>
        /// <returns></returns>
        [HttpGet("check")]
        public IActionResult Get()
        {
            return Content("ok");
        }
        #endregion //Action
    }
}

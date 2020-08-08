using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Core.Facade
{
    using HermesProduct.Base.Framework;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品业务接口
    /// </summary>
    public interface ICategoryBusiness : IBaseBL<Category, string>
    {
    }
}

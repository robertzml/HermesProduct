using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Core.BL
{
    using HermesProduct.Base.Framework;
    using HermesProduct.Base.System;
    using HermesProduct.Core.Facade;
    using HermesProduct.Core.DL;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品业务类
    /// </summary>
    public class CategoryBusiness: AbstractBusiness<Category, string>, ICategoryBusiness
    {
        #region Constructor
        public CategoryBusiness()
        {
            this.baseDal = new CategoryRepository();
        }
        #endregion //Constructor
    }
}

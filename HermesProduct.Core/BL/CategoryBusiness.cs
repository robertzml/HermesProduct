using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Core.BL
{
    using SqlSugar;
    using HermesProduct.Base.Framework;
    using HermesProduct.Base.System;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品类别业务类
    /// </summary>
    public class CategoryBusiness : AbstractBusiness<Category, string>, IBaseBL<Category, string>
    {
        #region Query
        /// <summary>
        /// 获取所有产品类别
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override async Task<List<Category>> FindAll(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<Category>().OrderBy(r => r.Number).ToListAsync();            
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (ErrorCode errorCode, string errorMessage, Category t) Create(Category entity, SqlSugarClient db = null)
        {
            entity.Id = Guid.NewGuid().ToString();
            return base.Create(entity, db);
        }
        #endregion //Query
    }
}

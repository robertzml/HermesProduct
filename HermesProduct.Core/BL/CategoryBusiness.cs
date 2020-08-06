using System;
using System.Collections.Generic;
using System.Text;

namespace HermesProduct.Core.BL
{
    using SqlSugar;
    using HermesProduct.Base.Framework;
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
        public override List<Category> FindAll(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<Category>().OrderBy(r => r.Number).ToList();            
        }

        /// <summary>
        /// 添加产品类别
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Category t) Create(Category entity, SqlSugarClient db = null)
        {
            entity.Id = Guid.NewGuid().ToString();
            return base.Create(entity, db);
        }
        #endregion //Query
    }
}

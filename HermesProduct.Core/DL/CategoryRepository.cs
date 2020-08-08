using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Core.DL
{
    using SqlSugar;
    using HermesProduct.Base.Framework;
    using HermesProduct.Base.System;
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品类别数据类
    /// </summary>
    public class CategoryRepository : AbstractRepository<Category, string>, IBaseDAL<Category, string>
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
        public override async Task<(ErrorCode errorCode, string errorMessage, Category t)> Create(Category entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var exist = await db.Queryable<Category>().CountAsync(r => r.Number == entity.Number);

            if (exist > 0)
            {
                return (ErrorCode.DuplicateNumber, ErrorCode.DuplicateNumber.DisplayName(), null);
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                return await base.Create(entity, db);
            }
        }

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async override Task<(ErrorCode errorCode, string errorMessage)> Update(Category entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var exist = await db.Queryable<Category>().CountAsync(r => r.Id != entity.Id && r.Number == entity.Number);

            if (exist > 0)
            {
                return (ErrorCode.DuplicateNumber, ErrorCode.DuplicateNumber.DisplayName());
            }
            else
            {
                return await base.Update(entity, db);
            }
        }
        #endregion //Query
    }
}

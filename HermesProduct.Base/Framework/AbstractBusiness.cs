using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Base.Framework
{
    using SqlSugar;
    using HermesProduct.Base.System;

    /// <summary>
    /// 抽象业务类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractBusiness<T, Tkey> : IBaseBL<T, Tkey>
        where T : class, IBaseEntity<Tkey>, new()
    {
        #region Function
        protected SqlSugarClient GetInstance()
        {
            var cs = Cache.Instance.Get("ConnectionString").ToString();

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = cs,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            return db;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual async Task<T> FindById(Tkey id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<T>().InSingleAsync(id);
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> FindAll(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<T>().ToListAsync();
        }

        /// <summary>
        /// 按条件查找对象
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual async Task<T> Single(Expression<Func<T, bool>> expression, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<T>().SingleAsync(expression);
        }

        /// <summary>
        /// 按条件查找对象
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> Query(Expression<Func<T, bool>> expression, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<T>().Where(expression).ToListAsync();
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual async Task<long> Count(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return await db.Queryable<T>().CountAsync();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual (ErrorCode errorCode, string errorMessage, T t) Create(T entity, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var t = db.Insertable(entity).ExecuteReturnEntity();
                return (ErrorCode.Success, "", t);
            }
            catch (Exception e)
            {
                return (ErrorCode.Exception, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual (ErrorCode errorCode, string errorMessage) Update(T entity, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var result = db.Updateable(entity).ExecuteCommand();
                if (result == 1)
                    return (ErrorCode.Success, "");
                else
                    return (ErrorCode.ObjectNotFound, "未更新对象");
            }
            catch (Exception e)
            {
                return (ErrorCode.Exception, e.Message);
            }
        }

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual (ErrorCode errorCode, string errorMessage) Delete(Tkey id, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var result = db.Deleteable<T>().In(id).ExecuteCommand();
                if (result == 1)
                    return (ErrorCode.Success, "");
                else
                    return (ErrorCode.ObjectNotFound, "未删除对象");
            }
            catch (Exception e)
            {
                return (ErrorCode.Exception, e.Message);
            }
        }
        #endregion //Method
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Base.Framework
{
    using HermesProduct.Base.System;

    /// <summary>
    /// 抽象业务类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Tkey"></typeparam>
    public abstract class AbstractBusiness<T, Tkey> : IBaseBL<T, Tkey>
        where T : class, IBaseEntity<Tkey>, new()
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        protected IBaseDAL<T, Tkey> baseDal;
        #endregion //Field

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual Task<T> FindById(Tkey id)
        {
            return baseDal.FindById(id);
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<T>> FindAll()
        {
            return baseDal.FindAll();
        }

        /// <summary>
        /// 按条件查找对象
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual Task<T> Single(Expression<Func<T, bool>> expression)
        {
            return baseDal.Single(expression);
        }

        /// <summary>
        /// 按条件查找对象
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual Task<List<T>> Query(Expression<Func<T, bool>> expression)
        {
            return baseDal.Query(expression);
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual Task<long> Count()
        {
            return baseDal.Count();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual Task<(ErrorCode errorCode, string errorMessage, T t)> Create(T entity)
        {
            return baseDal.Create(entity);
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual Task<(ErrorCode errorCode, string errorMessage)> Update(T entity)
        {
            return baseDal.Update(entity);
        }

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual Task<(ErrorCode errorCode, string errorMessage)> Delete(Tkey id)
        {
            return baseDal.Delete(id);
        }
        #endregion //Method
    }
}

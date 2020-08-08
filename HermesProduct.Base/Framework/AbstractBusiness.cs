using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesProduct.Base.Framework
{
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
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<T>> FindAll()
        {
            return baseDal.FindAll();
        }
        #endregion //Method
    }
}

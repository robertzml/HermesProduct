using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Services
{
    using HermesProduct.Core.Entity;

    /// <summary>
    /// 产品类别接口
    /// </summary>
    public interface ICategoryService
    {
        Task<List<Category>> FindAll();

        (bool success, string errorMessage, Category t) Create(Category entity);
    }
}

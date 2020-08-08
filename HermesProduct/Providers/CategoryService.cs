using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Providers
{
    using HermesProduct.Core.BL;
    using HermesProduct.Core.Entity;
    using HermesProduct.Services;

    public class CategoryService : ICategoryService
    {
        #region Field
       
        #endregion //Field

        #region Constructor

        #endregion //Constructor

        #region Method
        public async Task<List<Category>> FindAll()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            return await categoryBusiness.FindAll();
        }

        public (bool success, string errorMessage, Category t) Create(Category entity)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return categoryBusiness.Create(entity);
        }
        #endregion //Method
    }
}

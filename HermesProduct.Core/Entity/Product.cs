using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HermesProduct.Core.Entity
{
    using SqlSugar;
    using HermesProduct.Base.Framework;

    /// <summary>
    /// 产品类
    /// </summary>
    [SugarTable("pt_product")]
    public class Product : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Required]
        [Display(Name = "代码")]
        public string Number { get; set; }

        /// <summary>
        /// 产品类别ID
        /// </summary>
        [Display(Name = "产品类别ID")]
        public string CategoryId { get; set; }
        #endregion //Property
    }
}

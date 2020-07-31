using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HermesProduct.Core.Entity
{
    using SqlSugar;
    using HermesProduct.Base.Framework;

    /// <summary>
    /// 产品类别类
    /// </summary>
    [SugarTable("pt_category")]
    public class Category : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
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
        /// 上级ID
        /// </summary>
        [SugarColumn(ColumnName = "parent_id", IsNullable = true)]
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}

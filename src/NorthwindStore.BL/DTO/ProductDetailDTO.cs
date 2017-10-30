using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;
using DotVVM.Framework.Controls.DynamicData.Annotations;

namespace NorthwindStore.BL.DTO
{
    public class ProductDetailDTO : IEntity<int>
    {
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public string QuantityPerUnit { get; set; }

        [DotvvmEnforceClientFormat]
        public decimal? UnitPrice { get; set; }

        [DotvvmEnforceClientFormat]
        public short? UnitsInStock { get; set; }

        [DotvvmEnforceClientFormat]
        public short? UnitsOnOrder { get; set; }

        [DotvvmEnforceClientFormat]
        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
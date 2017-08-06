using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.DAL.Entities
{
    public partial class Products : IEntity<int>
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Column("ProductId")]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
    }
}

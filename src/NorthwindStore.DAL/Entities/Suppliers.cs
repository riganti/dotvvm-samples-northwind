using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.DAL.Entities
{
    public partial class Suppliers : IEntity<int>
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        [Column("SupplierId")]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}

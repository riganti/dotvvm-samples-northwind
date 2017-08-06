using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.DAL.Entities
{
    public partial class Customers : IEntity<string>
    {
        public Customers()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Orders>();
        }

        [Column("CustomerId")]
        public string Id { get; set; }
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

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

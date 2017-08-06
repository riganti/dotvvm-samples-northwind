using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.DAL.Entities
{
    public partial class Shippers : IEntity<int>
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Column("ShipperId")]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}

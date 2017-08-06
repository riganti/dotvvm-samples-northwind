using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.DAL.Entities
{
    public partial class Region : IEntity<int>
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        [Column("RegionId")]
        public int Id { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}

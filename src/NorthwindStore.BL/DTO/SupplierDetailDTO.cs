using DotVVM.Framework.Controls.DynamicData.Annotations;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindStore.BL.DTO
{
    public class SupplierDetailDTO : IEntity<int>
    {
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Style(FormControlCssClass = "short")]
        public string Region { get; set; }

        [Style(FormControlCssClass = "short")]
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [Style(FormControlCssClass = "short")]
        public string Phone { get; set; }

        [Style(FormControlCssClass = "short")]
        public string Fax { get; set; }
        public string HomePage { get; set; }

    }
}

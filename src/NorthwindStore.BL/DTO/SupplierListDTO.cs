using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthwindStore.BL.DTO
{
    public class SupplierListDTO
    {
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public int ProductsCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Queries;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.BL.Facades.Admin
{
    public class BaseListsFacade : FacadeBase
    {

        public Func<CategoryBasicListQuery> CategoryBasicListQuery { get; set; }

        public Func<SupplierBasicListQuery> SupplierBasicListQuery { get; set; }



        public List<CategoryBasicDTO> GetCategories()
        {
            using (UnitOfWorkProvider.Create())
            {
                return CategoryBasicListQuery().Execute().ToList();
            }
        }

        public List<SupplierBasicDTO> GetSuppliers()
        {
            using (UnitOfWorkProvider.Create())
            {
                return SupplierBasicListQuery().Execute().ToList();
            }
        }

    }
}

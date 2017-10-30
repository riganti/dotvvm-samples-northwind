using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;
using NorthwindStore.BL.Queries;

namespace NorthwindStore.BL.Facades.Admin
{
    public class AdminSuppliersFacade
        : AppCrudFacadeBase<Suppliers, int, SupplierListDTO, SupplierDetailDTO>
    {
        public AdminSuppliersFacade(Func<SupplierListQuery> queryFactory, IRepository<Suppliers, int> repository, IEntityDTOMapper<Suppliers, SupplierDetailDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }
    }
}

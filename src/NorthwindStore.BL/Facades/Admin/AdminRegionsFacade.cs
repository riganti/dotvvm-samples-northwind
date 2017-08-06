using System;
using System.Collections.Generic;
using System.Text;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.BL.Queries;
using NorthwindStore.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.BL.Facades.Admin
{
    public class AdminRegionsFacade : AppCrudFacadeBase<Region, int, RegionDTO, RegionDTO>
    {
        public AdminRegionsFacade(Func<RegionListQuery> queryFactory, IRepository<Region, int> repository, IEntityDTOMapper<Region, RegionDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }

    }
}

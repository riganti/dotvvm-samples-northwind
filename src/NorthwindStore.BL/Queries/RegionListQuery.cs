using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NorthwindStore.BL.DTO;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.BL.Queries
{
    public class RegionListQuery : AppQueryBase<RegionDTO>
    {
        public RegionListQuery(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }

        protected override IQueryable<RegionDTO> GetQueryable()
        {
            return Context.Regions
                .ProjectTo<RegionDTO>(Mapper.ConfigurationProvider);
        }
    }
}
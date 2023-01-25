using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NorthwindStore.BL.DTO;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.BL.Queries
{
    public class CategoryBasicListQuery : AppQueryBase<CategoryBasicDTO>
    {
        public CategoryBasicListQuery(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }

        protected override IQueryable<CategoryBasicDTO> GetQueryable()
        {
            return Context.Categories
                .OrderBy(c => c.CategoryName)
                .ProjectTo<CategoryBasicDTO>(Mapper.ConfigurationProvider);
        }
    }
}
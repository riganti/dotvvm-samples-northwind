using System.Linq;
using AutoMapper.QueryableExtensions;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.BL.Queries
{
    public class CategoryListQuery : AppQueryBase<CategoryListDTO>
    {
        public CategoryListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<CategoryListDTO> GetQueryable()
        {
            return Context.Categories
                .ProjectTo<CategoryListDTO>();
        }
    }
}
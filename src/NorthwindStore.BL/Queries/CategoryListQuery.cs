using System.Linq;
using AutoMapper.QueryableExtensions;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.BL.Queries
{
    public class CategoryListQuery : AppQueryBase<CategoryListDTO>, IFilteredQuery<CategoryListDTO, CategoryFilterDTO>
    {
        public CategoryFilterDTO Filter { get; set; }

        public CategoryListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<CategoryListDTO> GetQueryable()
        {
            return Context.Categories
                .FilterOptionalString(p => p.CategoryName, Filter.SearchText, StringFilterMode.Contains)
                .ProjectTo<CategoryListDTO>();
        }
    }
}
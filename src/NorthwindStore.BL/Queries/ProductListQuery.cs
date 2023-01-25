using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.BL.Queries
{
    public class ProductListQuery : AppQueryBase<ProductListDTO>, IFilteredQuery<ProductListDTO, ProductFilterDTO>
    {
        public ProductFilterDTO Filter { get; set; }


        public ProductListQuery(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }

        protected override IQueryable<ProductListDTO> GetQueryable()
        {
            return Context.Products
                .FilterOptionalString(p => p.ProductName, Filter.SearchText, StringFilterMode.Contains)
                .FilterOptional(p => p.CategoryId, Filter.CategoryId)
                .FilterOptional(p => p.SupplierId, Filter.SupplierId)
                .ProjectTo<ProductListDTO>(Mapper.ConfigurationProvider);
        }

    }
}
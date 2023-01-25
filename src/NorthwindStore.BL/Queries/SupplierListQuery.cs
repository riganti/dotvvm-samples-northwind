using System.Linq;
using NorthwindStore.BL.DTO;
using Riganti.Utils.Infrastructure.Core;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace NorthwindStore.BL.Queries
{
    public class SupplierListQuery : AppQueryBase<SupplierListDTO>
    {
        public SupplierListQuery(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider, mapper)
        {
        }

        protected override IQueryable<SupplierListDTO> GetQueryable()
        {
            return Context.Suppliers
                .ProjectTo<SupplierListDTO>(Mapper.ConfigurationProvider);
        }
    }
}
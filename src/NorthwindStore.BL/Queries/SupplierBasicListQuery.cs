using System.Linq;
using NorthwindStore.BL.DTO;
using Riganti.Utils.Infrastructure.Core;
using AutoMapper.QueryableExtensions;

namespace NorthwindStore.BL.Queries
{
    public class SupplierBasicListQuery : AppQueryBase<SupplierBasicDTO>
    {
        public SupplierBasicListQuery(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        protected override IQueryable<SupplierBasicDTO> GetQueryable()
        {
            return Context.Suppliers
                .OrderBy(s => s.CompanyName)
                .ProjectTo<SupplierBasicDTO>();
        }
    }
}
using System;
using System.Collections.Generic;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.BL.Queries;
using NorthwindStore.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.BL.Facades.Admin
{
    public class AdminProductsFacade : AppFilteredCrudFacadeBase<Products, int, ProductListDTO, ProductDetailDTO, ProductFilterDTO>
    {
        public AdminProductsFacade(Func<ProductListQuery> queryFactory, IRepository<Products, int> repository, IEntityDTOMapper<Products, ProductDetailDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }

        public void BatchOrder(List<int> productIds, int quantity)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var products = Repository.GetByIds(productIds);

                foreach (var product in products)
                {
                    product.UnitsOnOrder += (short)quantity;
                }

                uow.Commit();
            }
        }
    }
}
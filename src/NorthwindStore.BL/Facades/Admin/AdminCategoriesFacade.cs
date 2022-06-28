using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.BL.Queries;
using NorthwindStore.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.BL.Facades.Admin
{
    public class AdminCategoriesFacade : AppCrudFacadeBase<Categories, int, CategoryListDTO, CategoryDetailDTO>
    {
        public AdminCategoriesFacade(Func<CategoryListQuery> queryFactory, IRepository<Categories, int> repository, IEntityDTOMapper<Categories, CategoryDetailDTO> mapper) : base(queryFactory, repository, mapper)
        {
        }


        public byte[] GetImage(int categoryId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var category = Repository.GetById(categoryId);
                return category?.Picture;
            }
        }

        public void SaveImage(int categoryId, Stream stream)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            using (var uow = UnitOfWorkProvider.Create())
            {
                var category = Repository.GetById(categoryId);
                category.Picture = buffer;
                uow.Commit();
            }
        }
    }
}

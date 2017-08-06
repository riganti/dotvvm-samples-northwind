using System;
using System.Collections.Generic;
using System.Text;
using NorthwindStore.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace NorthwindStore.BL.Repositories
{
    public class AppRepositoryBase<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, AppDbContext> where TEntity : class, IEntity<TKey>, new()
    {
        public AppRepositoryBase(IEntityFrameworkUnitOfWorkProvider<AppDbContext> unitOfWorkProvider, IDateTimeProvider dateTimeProvider) : base(unitOfWorkProvider, dateTimeProvider)
        {
        }

        public AppRepositoryBase(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider) : base(unitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}

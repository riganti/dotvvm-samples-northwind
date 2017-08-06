using System;
using System.Collections.Generic;
using System.Text;
using NorthwindStore.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace NorthwindStore.BL.Queries.FirstLevel
{
    public class AppFirstLevelQueryBase<TResult> : EntityFrameworkFirstLevelQueryBase<TResult, AppDbContext> where TResult : class
    {
        public AppFirstLevelQueryBase(IEntityFrameworkUnitOfWorkProvider<AppDbContext> unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }

        public AppFirstLevelQueryBase(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }
    }
}

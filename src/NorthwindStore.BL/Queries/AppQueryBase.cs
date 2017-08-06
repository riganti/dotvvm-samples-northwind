using System;
using System.Collections.Generic;
using System.Text;
using NorthwindStore.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace NorthwindStore.BL.Queries
{
    public abstract class AppQueryBase<TResult> : EntityFrameworkQuery<TResult, AppDbContext>
    {
        public AppQueryBase(IUnitOfWorkProvider unitOfWorkProvider) : base(unitOfWorkProvider)
        {
        }
    }
}

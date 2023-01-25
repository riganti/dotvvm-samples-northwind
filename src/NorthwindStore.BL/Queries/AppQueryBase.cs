using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NorthwindStore.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace NorthwindStore.BL.Queries
{
    public abstract class AppQueryBase<TResult> : EntityFrameworkQuery<TResult, AppDbContext>
    {
        public IMapper Mapper { get; }

        public AppQueryBase(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper) : base(unitOfWorkProvider)
        {
            Mapper = mapper;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NorthwindStore.BL;
using NorthwindStore.BL.Queries;
using NorthwindStore.BL.Queries.FirstLevel;
using NorthwindStore.DAL;
using Riganti.Utils.Infrastructure.AutoMapper;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Services.Facades;

namespace NorthwindStore.App.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        private readonly DbContextOptions<AppDbContext> dbContextOptions;

        public DataAccessInstaller(string connectionString)
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<Func<AppDbContext>>()
                    .Instance(() => new AppDbContext(dbContextOptions))
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkProvider>()
                    .ImplementedBy<EntityFrameworkUnitOfWorkProvider<AppDbContext>>()
                    .LifestyleSingleton(),
                
                Component.For<IUnitOfWorkRegistry>()
                    .UsingFactoryMethod(p => new AspNetCoreUnitOfWorkRegistry(p.Resolve<IHttpContextAccessor>(), new AsyncLocalUnitOfWorkRegistry()))
                    .LifestyleSingleton(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(AppQueryBase<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(AppFirstLevelQueryBase<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn(typeof(IRepository<,>))
                    .WithServiceAllInterfaces()
                    .WithServiceSelf()
                    .LifestyleTransient(),

                Component.For(typeof(IRepository<,>))
                    .ImplementedBy(typeof(EntityFrameworkRepository<,>))
                    .IsFallback()
                    .LifestyleTransient(),

                Component.For<IDateTimeProvider>()
                    .Instance(new UtcDateTimeProvider()),
                
                Component.For(typeof(IEntityDTOMapper<,>))
                    .ImplementedBy(typeof(EntityDTOMapper<,>))
                    .LifestyleSingleton()
            );

        }
    }
}

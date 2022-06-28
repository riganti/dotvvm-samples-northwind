using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NorthwindStore.BL;

namespace NorthwindStore.App.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<BusinessLayer>()
                    .BasedOn<Profile>()
                    .WithServiceBase()
                    .LifestyleSingleton(),

                Component.For<IMapper>()
                    .UsingFactoryMethod(() =>
                    {
                        var mapperConfiguration = new MapperConfiguration(cfg =>
                        {
                            var profiles = container.ResolveAll<Profile>();

                            foreach (var profile in profiles)
                            {
                                cfg.AddProfile(profile);
                            }
                        });
                        return mapperConfiguration.CreateMapper();
                    })
                    .LifestyleSingleton()
            );
        }

        internal static void InitAutoMapper(IWindsorContainer container)
        {
            var mapper = container.Resolve<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}

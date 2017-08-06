using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NorthwindStore.BL.Mappings;

namespace NorthwindStore.App.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Classes.FromAssemblyContaining<IMapping>()
                    .BasedOn<IMapping>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton()

            );
        }

        internal static void InitAutoMapper(IWindsorContainer container)
        {
            // configure all mappings now
            Mapper.Initialize(mapper =>
            {
                foreach (var mapping in container.ResolveAll<IMapping>())
                {
                    mapping.ConfigureMaps(mapper);
                }
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}

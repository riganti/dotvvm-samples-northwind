using System;
using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class RegionMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Regions, RegionDTO>();
            mapper.CreateMap<RegionDTO, Regions>()
                .ForMember(r => r.Id, m => m.Ignore())
                .ForMember(r => r.Territories, m => m.Ignore());
        }
    }
}

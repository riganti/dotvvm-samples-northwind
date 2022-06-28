using System;
using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class RegionMapping : Profile
    {
        public RegionMapping()
        {
            CreateMap<Regions, RegionDTO>();
            CreateMap<RegionDTO, Regions>()
                .ForMember(r => r.Id, m => m.Ignore())
                .ForMember(r => r.Territories, m => m.Ignore());
        }
    }
}

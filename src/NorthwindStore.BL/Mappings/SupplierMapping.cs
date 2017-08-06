using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class SupplierMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Suppliers, SupplierBasicDTO>();
        }
    }
}
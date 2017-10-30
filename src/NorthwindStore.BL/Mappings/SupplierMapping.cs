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

            mapper.CreateMap<Suppliers, SupplierListDTO>();

            mapper.CreateMap<Suppliers, SupplierDetailDTO>();
            mapper.CreateMap<SupplierDetailDTO, Suppliers>()
                .ForMember(s => s.Id, m => m.Ignore())
                .ForMember(s => s.Products, m => m.Ignore());
        }
    }
}
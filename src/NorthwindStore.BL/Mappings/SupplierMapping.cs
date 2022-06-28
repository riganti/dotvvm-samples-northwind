using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class SupplierMapping : Profile
    {
        public SupplierMapping()
        {
            CreateMap<Suppliers, SupplierBasicDTO>();

            CreateMap<Suppliers, SupplierListDTO>();

            CreateMap<Suppliers, SupplierDetailDTO>();
            CreateMap<SupplierDetailDTO, Suppliers>()
                .ForMember(s => s.Id, m => m.Ignore())
                .ForMember(s => s.Products, m => m.Ignore());
        }
    }
}
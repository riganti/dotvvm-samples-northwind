using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Products, ProductListDTO>()
                .ForMember(p => p.SupplierName, m => m.MapFrom(p => p.Supplier.CompanyName))
                .ForMember(p => p.CategoryName, m => m.MapFrom(p => p.Category.CategoryName));

            CreateMap<Products, ProductDetailDTO>();
            CreateMap<ProductDetailDTO, Products>()
                .ForMember(p => p.Id, m => m.Ignore())
                .ForMember(p => p.Category, m => m.Ignore())
                .ForMember(p => p.Supplier, m => m.Ignore())
                .ForMember(p => p.OrderDetails, m => m.Ignore());
        }
    }
}
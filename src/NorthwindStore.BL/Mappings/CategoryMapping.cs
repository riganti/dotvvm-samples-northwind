using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Categories, CategoryBasicDTO>();

            CreateMap<Categories, CategoryListDTO>()
                .ForMember(c => c.ImageUrl, m => m.MapFrom(c => $"/image/category/{c.Id}"));


            CreateMap<Categories, CategoryDetailDTO>()
                .ForMember(c =>c.HasPicture, m => m.MapFrom(c => c.Picture != null));

            CreateMap<CategoryDetailDTO, Categories>()
                .ForMember(c => c.Id, m => m.Ignore())
                .ForMember(c => c.Picture, m => m.Ignore())
                .ForMember(c => c.Products, m => m.Ignore())
                .AfterMap((dto, entity) => {
                    if (!dto.HasPicture)
                    {
                        entity.Picture = null;
                    }
                });
        }
    }
}
using AutoMapper;
using NorthwindStore.BL.DTO;
using NorthwindStore.DAL.Entities;

namespace NorthwindStore.BL.Mappings
{
    public class CategoryMapping : IMapping
    {
        public void ConfigureMaps(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Categories, CategoryBasicDTO>();

            mapper.CreateMap<Categories, CategoryListDTO>()
                .ForMember(c => c.ImageUrl, m => m.MapFrom(c => $"/image/category/{c.Id}"));


            mapper.CreateMap<Categories, CategoryDetailDTO>()
                .ForMember(c =>c.HasPicture, m => m.MapFrom(c => c.Picture != null));

            mapper.CreateMap<CategoryDetailDTO, Categories>()
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
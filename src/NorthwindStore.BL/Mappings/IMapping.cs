using AutoMapper;

namespace NorthwindStore.BL.Mappings
{
    public interface IMapping
    {
        void ConfigureMaps(IMapperConfigurationExpression mapper);
    }
}
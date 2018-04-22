using AutoMapper;

namespace MVC.Infrastructure.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
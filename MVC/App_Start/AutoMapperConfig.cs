using AutoMapper;
using MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVC.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            Mapper.Initialize(cfg =>
            {
                LoadStandardMappings(types, cfg);
                LoadCustomMappings(types, cfg);
            });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMapping).IsAssignableFrom(t) &&
                              !t.IsAbstract && !t.IsInterface
                        select (IHaveCustomMapping)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(cfg);
            }
        }
    }
}

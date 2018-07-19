using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.AutoMapperMe
{
    public class MapperManagement : IMapperManagement, IMapper
    {
        public void Initialize(string[] strs, bool isValid)
        {
            var configs = new List<IAutoMapprConfig>();

            foreach (var str in strs)
            {
                var assembly = Assembly.Load(str);
                var config = from type in assembly.GetTypes()
                             where typeof(IAutoMapprConfig).IsAssignableFrom(type)
                             select assembly.CreateInstance(type.FullName) as IAutoMapprConfig;

                configs.AddRange(config);
            }

            Mapper.Initialize(config => configs.ForEach(e => e.Create(config)));

            if (isValid)
            {
                Mapper.AssertConfigurationIsValid();
            }
        }

        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}

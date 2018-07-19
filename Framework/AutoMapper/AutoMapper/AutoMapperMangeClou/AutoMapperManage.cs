using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class AutoMapperManage : IAutoMapperManage
    {
        public void Initialize(string[] strs, bool isValid)
        {
            var configs = new List<AutoMapprConfig>();

            foreach (var str in strs)
            {
                var assembly = Assembly.Load(str);
                var config = from type in assembly.GetTypes()
                             where typeof(AutoMapprConfig).IsAssignableFrom(type)
                             select assembly.CreateInstance(type.FullName) as AutoMapprConfig;

                configs.AddRange(config);
            }

            Mapper.Initialize(config => configs.ForEach(e => e.Create(config)));

            if (isValid)
            {
                Mapper.AssertConfigurationIsValid();
            }
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wingon.Frameworks.Map;

namespace Ticket.Offline.Service
{
    /// <summary>
    /// OfflineService.Site 所有用到的AutoMapper配置都放在这里
    /// </summary>
    public static class AutoMapperConfig
    {
        static AutoMapperConfig()
        {
            //添加所有profile
            var assembly = Assembly.GetExecutingAssembly();
            var subTypeQuery = from t in assembly.GetTypes()
                               where (typeof(Profile).IsAssignableFrom(t))
                               select t;
            foreach (var type in subTypeQuery)
            {
                var profile = assembly.CreateInstance(type.FullName) as Profile;
                if (profile == null)
                {
                    continue;
                }
                AutoMapperManager.AddProfile(profile);
            }
            AutoMapperManager.Initialize();
        }


        public static TDestion Map<TDestion>(this object source)
        {
            return Mapper.Map<TDestion>(source);
        }

        public static TDestion Map<TSource, TDestion>(this TSource source)
        {
            return Mapper.Map<TSource, TDestion>(source);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingon.Frameworks.Map
{
    /// <summary>
    ///     优化AutoMap映射工具，解决AutoMap只能Initialize一次的问题
    /// </summary>
    public class AutoMapperManager
    {
        /// <summary>
        /// 存储所有的profile
        /// </summary>
        static ConcurrentBag<Profile> Profiles;
        static AutoMapperManager()
        {
            Profiles = new ConcurrentBag<Profile>();
        }

        /// <summary>
        /// 新增Profile,必須放在靜態構造函數里
        /// </summary>
        /// <param name="profile"></param>
        public static void AddProfile(Profile profile)
        {
            Profiles.Add(profile);
        }

        /// <summary>
        /// 初始化，可以多次调用，同时之前的Profile也会生效
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                Profiles.ToList().ForEach(file =>
                {
                    config.AddProfile(file);
                });
            });

        }
    }
}

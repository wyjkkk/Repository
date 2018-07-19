using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Niject.NinJectMe
{
    public class NinjectContainer : IContainerMangement, IContainer
    {
        public T GetService<T>()
        {
            return kernel.Get<T>();
        }

        public void Initialize(string[] str)
        {
            var ninjectModuleAssembly = new List<Assembly>();

            str.ToList().ForEach(e => ninjectModuleAssembly.Add(Assembly.Load(e)));

            kernel.Load(ninjectModuleAssembly);
        }

        private readonly StandardKernel kernel = new StandardKernel();
    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Niject
{
    public class NiJectManagement : INijectManagement
    {
        public void Initialize(string[] str)
        {
            var kernel = new StandardKernel();
            var ninjectModuleAssembly = new List<Assembly>();

            str.ToList().ForEach(e => ninjectModuleAssembly.Add(Assembly.Load(e)));

            kernel.Load(ninjectModuleAssembly);
        }
    }
}

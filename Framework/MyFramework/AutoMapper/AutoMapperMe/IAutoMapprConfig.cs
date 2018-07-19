using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    interface IAutoMapprConfig
    {
        void Create(IMapperConfigurationExpression config);
    }
}

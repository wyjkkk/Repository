﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niject.NinJectMe
{
    interface IContainer
    {
        T GetService<T>();
    }
}

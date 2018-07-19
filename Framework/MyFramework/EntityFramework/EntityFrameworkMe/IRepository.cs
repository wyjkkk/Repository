using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.EntityFrameworkMe
{
    interface IRepository<Entity>
        where Entity:class
    {
        void Add(Entity entity);

        void Delete(Entity entity);

        void Update(Entity entity);

        void Save();
    }
}

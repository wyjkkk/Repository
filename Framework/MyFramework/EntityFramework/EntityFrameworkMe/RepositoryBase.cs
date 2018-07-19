using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.EntityFrameworkMe
{
    public class RepositoryBase<Entity> : IRepository<Entity>
         where Entity : class
    {
        public RepositoryBase(DbContext dbcontex)
        {
            this.dbcontex = dbcontex;
        }

        public void Add(Entity entity)
        {
            dbcontex.Set<Entity>().Add(entity);
        }

        public void Delete(Entity entity)
        {
            dbcontex.Set<Entity>().Remove(entity);
        }

        public void Update(Entity entity)
        {
            //dbcontex.Set<Entity>().en
        }

        public void Save()
        {
            dbcontex.SaveChanges();
        }

        private DbContext dbcontex;
    }
}

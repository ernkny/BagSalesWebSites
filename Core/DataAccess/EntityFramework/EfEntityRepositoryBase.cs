using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext BagContext = new TContext())
            {
                var addedEntity = BagContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                BagContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext BagContext = new TContext())
            {
                var deletedEntity = BagContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                BagContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext BagContext = new TContext())
            {
                return BagContext.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext BagContext = new TContext())
            {
                return filter == null
                    ? BagContext.Set<TEntity>().ToList()
                    : BagContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext BagContext = new TContext())
            {
                var updatedEntity = BagContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                BagContext.SaveChanges();
            }
        }
    }
}

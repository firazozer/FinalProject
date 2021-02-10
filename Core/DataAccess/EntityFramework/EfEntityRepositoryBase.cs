using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()

    {
        public void Add(TEntity entity)
        {
            // IDisposable pattern implementation of C#
            using (TContext conctex = new TContext())
            {
                var addedEntity = conctex.Entry(entity);
                addedEntity.State = EntityState.Added;
                conctex.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext conctex = new TContext())
            {
                var deletedEntity = conctex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                conctex.SaveChanges();
            }
        }

        public  TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext conctex = new TContext())
            {
                var updatedEntity = conctex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                conctex.SaveChanges();
            }
        }
    }
}

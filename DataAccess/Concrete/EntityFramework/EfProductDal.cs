using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // IDisposable pattern implementation of C#
            using (NorthwindContext conctex = new NorthwindContext())
            {
                var addedEntity = conctex.Entry(entity);
                addedEntity.State = EntityState.Added;
                conctex.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext conctex = new NorthwindContext())
            {
                var deletedEntity = conctex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                conctex.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter )
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
       
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext conctex = new NorthwindContext())
            {
                var updatedEntity = conctex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                conctex.SaveChanges();
            }
        }
    }
}

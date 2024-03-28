using DataAccess.Abstracts;
using Entities.Concretes;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Concretes.EntityFramewrork
{
    public class EfProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            //using ifadesi genellikle belirli türdeki kaynakların düzgün bir şekilde yönetilmesini sağlar.
            using (BaseDbContext context = new()) {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using(BaseDbContext context = new())
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            using(BaseDbContext context = new())
            {
                return context.Products.ToList();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            using(BaseDbContext context = new())
            {
                return context.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Product product)
        {
            using (BaseDbContext context = new()) 
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }
    }
}

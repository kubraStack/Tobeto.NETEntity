using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        List<Product> products;
        public InMemoryProductRepository()
        {
            products = new List<Product>();
        }
        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            //LINQ => SQL'in C# hali => C#'daki sorgulama dili
            Product? product = products.Find(p => p.Id == id);
            return product;
            //return products.Where(p => p.Id == p.Id).FirstOrDefault();
        }

        public void Update(Product product)
        {
           //InMomery olduğundan atla.
        }
    }
}

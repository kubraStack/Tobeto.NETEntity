using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public abstract class BaseProductService : IProductServices
    {
        public void AddProductWithLogging(Product product)
        {
            Console.WriteLine("Loglama işlemi yapıldı.");
            AddProduct(product);
        }
        public abstract void AddProduct(Product product);

        public abstract void DeleteProduct(Product product);

        public abstract void UpdateProduct(Product product);
    }
}

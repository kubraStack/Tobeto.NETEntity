using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IProductServices
    {
        //Soyutlamada(Interface) => Somut içerikler olmaz. Sadece işlemleri tanımlıyoruz.Burada tanımlananlar implemente edilen sınıflarda kullanılmak zorundadır.
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}

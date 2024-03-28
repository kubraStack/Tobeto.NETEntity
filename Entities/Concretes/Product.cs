using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Product
    {

        public Product()
        {

        }

        public Product(int ıd, string name, double unitPrice, int stock, int categoryId)
        {
            Id = ıd;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        //ORM'de ilişkili olduğumuz nesneyi direk sanal(virtual) olarak ekleriz
        //Constructor oluştururken virtual alanlara yer verilmez.
        public virtual  Category Category { get; set; }
    }
}

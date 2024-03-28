using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    //Genel tanıma(model) class deriz.
    public class Product
    {  //Erişim belirteci => Yazılımın herhangi bir yerinden nekadar ulaşılabilir olduğunu belirtir.
        //private => ilgili nesneye özel
        //public => Tüm dış dünyaya açık

        //geri dönüş parametresi yoktur. nesne ismiyle aynıdır. Newlenme işleminde çağırılan metot
        //Eğer ilgili class hiçbir ctor tanımı içmermiyor ise boş parametreli ctor default olarak eklenir.
      
        //All Args Ctor 
        public Product()
        {
            Console.WriteLine("Bir product nesnesi üretildi.");
        }
        //No Args Ctor
        //parametreli ctor varsa kullanırken boş olanı kullanılamaz
        public Product(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; } //Field(Alanlar)
        public string Name { get; set; }
    }
}

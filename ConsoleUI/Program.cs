
using ConsoleUI;

Console.WriteLine("Hello World");
 //OOP  => Gerçek hayattaki nesneyi bilgisayar tanıtmak.

    
//Kalıptan üretilen bir örnek
//instance = newlemek
//Yeni güncelleme ile 8 ve üzeri versiyonda newden sonra Product yazmaya gerek yoktur solda tanımlanır.
Product product = new Product(1,"Laptop"); //Constructor, ctor => instance yaparken metot çağırılır oda ctor'dur.(Yapıcı Block)


Product product2 = new Product();
product2.Name = "Tablet";
product2.Id = 2;
Console.WriteLine("Deneme");

Customer customer = new Customer();

//Min user'ın gereksinimlerini karşılayacak bir obje
User user = new Admin();
User user2 = new Customer();

// OOP Concepts -> Access Modifiers(Erişim Belirteci), Constructor,  Inheritance, Polymorphism(Yerine Geçilebilirlik/Çok Biçimlik)
//Abstraction, Interface
//Servislerin servis olabilmek için gereksinimlerini belirler(Interface)

//polf'i işçi sınıflara da nesne olarak bakar.Manager,DaL
//Veritabanı nesnesi -> MssqlNesnesi,PostgreSqlNesnesi
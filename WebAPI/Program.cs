using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramewrork;
using DataAccess.Concretes.InMemory;
using WebAPI.Controllers;

namespace WebAPI
{
    /*
     Her uygulamanýn temeli console uygulamasýdýr.Ýþletim sisteminde bir console uygulamasý ayaða kalkar ve o uygulama üzerinde iþlemler yaparýz.
     Console uygulamasý ayaða kalktýðý anda ayný anda bir web sunucusuda istekleri dinlemek için ayaða kalkar.
     Buradaki program.cs'in amacý da budur.
     
     Endpoint(Bitiþ Noktasý) => Her isteðin atýldýðý ve cevaplandýðý endpoint vardýr.Her endpoint bir methoda baðlýdýr.Ýsteðe göre o method çalýþýr.
     Controller Dosyasý => Endpointleri geliþtirerek týpký konsolda olduðu gibi yazdýðýmýz fonksiyonlara kullanýcýnýn istek atabileceði noktalarý tanýmlarýz bunlarý da controller klasöründe tutarýz.

     */
    public class Program
    {
        public static void Main(string[] args)
        {
            //Burada api build etmiþ(inþa edilmiþ).En sonda api run etmiþ.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Singleton-Scoped-Transient -> Lifetime'dýr
            //Singleton => Üretilen baðýmlýlýk uygulama açýk olduðu sürece tek bir kere newlenir.Her enjeksiyonda o intance kullanýlýr.
            //Scoped => (API isteði)Ýstek baþýna 1 instance oluþturur.
            //Transient => Her adýmda(her talepte) yeni 1 instance oluþturur.
            
            builder.Services.AddSingleton<IProductService, ProductManager>();
            //AddSingleton<IProductService, ProductManager>(): Bu yöntem, belirli bir servisin (IProductService arayüzü) somut bir uygulamasýný (ProductManager sýnýfý) kaydeder ve bu uygulamanýn tek bir örneðinin uygulama boyunca kullanýlmasýný saðlar. Yani, her istek için ayný örneðin kullanýlmasýný garanti eder.
            //Bu, uygulamanýn boyunca bir kez oluþturulan ve paylaþýlan bir servis örneði saðlar.
            builder.Services.AddSingleton<ICategoryService, CategoryManager>();
            builder.Services.AddSingleton<IProductRepository, EfProductRepository>();
            builder.Services.AddDbContext<BaseDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); //.Run() Sürekli çalýþýr
        }
    }
}

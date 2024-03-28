using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramewrork;
using DataAccess.Concretes.InMemory;
using WebAPI.Controllers;

namespace WebAPI
{
    /*
     Her uygulaman�n temeli console uygulamas�d�r.��letim sisteminde bir console uygulamas� aya�a kalkar ve o uygulama �zerinde i�lemler yapar�z.
     Console uygulamas� aya�a kalkt��� anda ayn� anda bir web sunucusuda istekleri dinlemek i�in aya�a kalkar.
     Buradaki program.cs'in amac� da budur.
     
     Endpoint(Biti� Noktas�) => Her iste�in at�ld��� ve cevapland��� endpoint vard�r.Her endpoint bir methoda ba�l�d�r.�ste�e g�re o method �al���r.
     Controller Dosyas� => Endpointleri geli�tirerek t�pk� konsolda oldu�u gibi yazd���m�z fonksiyonlara kullan�c�n�n istek atabilece�i noktalar� tan�mlar�z bunlar� da controller klas�r�nde tutar�z.

     */
    public class Program
    {
        public static void Main(string[] args)
        {
            //Burada api build etmi�(in�a edilmi�).En sonda api run etmi�.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Singleton-Scoped-Transient -> Lifetime'd�r
            //Singleton => �retilen ba��ml�l�k uygulama a��k oldu�u s�rece tek bir kere newlenir.Her enjeksiyonda o intance kullan�l�r.
            //Scoped => (API iste�i)�stek ba��na 1 instance olu�turur.
            //Transient => Her ad�mda(her talepte) yeni 1 instance olu�turur.
            
            builder.Services.AddSingleton<IProductService, ProductManager>();
            //AddSingleton<IProductService, ProductManager>(): Bu y�ntem, belirli bir servisin (IProductService aray�z�) somut bir uygulamas�n� (ProductManager s�n�f�) kaydeder ve bu uygulaman�n tek bir �rne�inin uygulama boyunca kullan�lmas�n� sa�lar. Yani, her istek i�in ayn� �rne�in kullan�lmas�n� garanti eder.
            //Bu, uygulaman�n boyunca bir kez olu�turulan ve payla��lan bir servis �rne�i sa�lar.
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

            app.Run(); //.Run() S�rekli �al���r
        }
    }
}

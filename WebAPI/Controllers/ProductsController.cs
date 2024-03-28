using Business.Abstracts;
using Business.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Controller isimleri genellikle controller ile biter ve çoğul olarak kullanılır.
//Controller'ları .net otomatik newler.

namespace WebAPI.Controllers
{
    //Attribute'lar => Bulunduğu yere bazı özellikler kazandırır.
    //api/products isteği gelirse bu controller çalışsın demiş oluruz.Köşeli parantez içinde belirtilen controllerin ismi olmuş oluyor.
    [Route("api/[controller]")] // Route attribute'ünü bir class'a verirsek attribute'in içine verdiğimiz parametreye istek geldiğinde bu controller devreye girsin demiş oluruz.
    [ApiController] // => ApiController'ı bir class'ın üzerine verirsek  o class'ın ApiController görevi yapacağını belirtmiş oluruz.

    public class ProductsController : ControllerBase
    {
        //In-Memory
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        //Newleme yerine DI CONTAINER kullanılır.
        // DI CONTAINER(Dependency Injection) => Bir yazılım uygulamasında bağımlılıkların yöenetimini kolaylaştırmak için kullanılan bir bileşendir.
        // Bu, DI prensiplerini(bağımlılıkların dışarıdan enjekte edilmesi) uygulamak için kullanılan bir araçtır.
        //Bir bileşenin kendi bağımlılıklarını yönetmek yerine, dışarıdan sağlanmasını sağlar.DI Container, bu bağımlılıkları yönetmek için ve enjekte etmek için kullanılır.

        /* DI CONTAINER genellikle aşağıdaki işlevleri sağlar:
         * 1-Bağımlılıkları Çözme(Dependency Resolution)
         * 2-Hayat Döngüsü Yönetimi(Lifecycle Management)
         * 3-Konfigürasyon(Configuratuion)
         * 4-Ayrıştırma(Decoupling)
         */

        //Interface'i newlemek için program.cs 'de IoC ve DI Container ile yapılır.
        // IoC(Inversion of Control)(Kontrolün Tersin Çevrilmesi) kavramı, bir yazılım bileşeninin diğer bir bileşenin oluşturulması ve yönetilmesi gibi  sorumluluklardan kurulmasıdır.
        //Geleneksel olarak bir beleşenin kendi bağımlılıklarını oluşturup yönettiği "kontrol" modeli vardır.Ancak IoC prensibi, bu kontrolü bir DI Container veya benzeri bir mekanizma aracılığıyla dışarıya taşır.
        //Bu, bileşenlerin bağımlılıklarını doğrudan oluşturmak ve yönetmek yerine, dışarıdan enjekte edilmesini sağlar.
        /*IoC, yazılım geliştirme sürecinde şu avantajları sağlar:
         * 1-Esneklik ve Değiştirilebilirlik
         * 2-Test Edilebilirlik
         * 3-Kodun Tekrar Kullanılabilirliği
         * 4-Bieleşenler Arasında Gevşek Bağlılık
         
         */



        [HttpGet]
        public List<Product> GetAll()
        {
          return _productService.GetAll();
        }

        [HttpPost]
        //Ürün Ekleme Özelliği
        public void Add([FromBody] Product product)
        {
            //Validation, İş Kuralı, Authentication
            //Veritabanı bağlantısı
            
           _productService.Add(product);

        }
    }
    // SOLID => S => SINGLE RESPONSIBILITY
}

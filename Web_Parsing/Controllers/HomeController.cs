using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net;
using System.Text;
using Web_Parsing.Models;

namespace Web_Parsing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            List<string> location = new List<string>();
            List<string> urls = new List<string>();

            // web client ile bir web sitesinin tüm içeriðini string olarak aldýk.
            var web = new WebClient();
            web.Encoding = Encoding.UTF8;
            var html = web.DownloadString("https://deprem.afad.gov.tr/last-earthquakes.html");

            // ardýndan, HtmlAgilityPack'e , çektiðimiz html dosyasýný yükledik. 
            var doc =new  HtmlDocument();
            doc.LoadHtml(html);

            // Yüklemenin ardýndan, HTml içerisindeki, yakalamak istediðimiz boðumlarý xpath dili ile yakaladýk.
            // AÞaðýda yazýlan XPath dili, td içerisindeki 7. sýradaki td'i alma iþine yarar
            var result =   doc.DocumentNode.SelectNodes("//td[position()=7]");
            foreach (var item in result)
            {
                // ilgili td yakalandýktan sonra, td'nin içerisindeki text bir koleksiyona eklenir.
                location.Add(item.InnerText);
            }

            // Ödev : Ýstediðiniz herhangi bir siteyi parse edip, Xpath kullanarak istediðiniz html'i almanýzý saðlar.Sizde bu örnek üzerinden istediðiniz bir sitenin bir kýsmýný parse edebilirsiniz.
          
            return View("Index",location);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

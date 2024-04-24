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

            // web client ile bir web sitesinin t�m i�eri�ini string olarak ald�k.
            var web = new WebClient();
            web.Encoding = Encoding.UTF8;
            var html = web.DownloadString("https://deprem.afad.gov.tr/last-earthquakes.html");

            // ard�ndan, HtmlAgilityPack'e , �ekti�imiz html dosyas�n� y�kledik. 
            var doc =new  HtmlDocument();
            doc.LoadHtml(html);

            // Y�klemenin ard�ndan, HTml i�erisindeki, yakalamak istedi�imiz bo�umlar� xpath dili ile yakalad�k.
            // A�a��da yaz�lan XPath dili, td i�erisindeki 7. s�radaki td'i alma i�ine yarar
            var result =   doc.DocumentNode.SelectNodes("//td[position()=7]");
            foreach (var item in result)
            {
                // ilgili td yakaland�ktan sonra, td'nin i�erisindeki text bir koleksiyona eklenir.
                location.Add(item.InnerText);
            }

            // �dev : �stedi�iniz herhangi bir siteyi parse edip, Xpath kullanarak istedi�iniz html'i alman�z� sa�lar.Sizde bu �rnek �zerinden istedi�iniz bir sitenin bir k�sm�n� parse edebilirsiniz.
          
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

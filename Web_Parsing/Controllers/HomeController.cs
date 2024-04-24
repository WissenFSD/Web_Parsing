using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult MoggleSearch(string search)
        {
            List<string> location = new List<string>();
            List<string> urls = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load("https://deprem.afad.gov.tr/last-earthquakes.html");
            var result =   doc.DocumentNode.SelectNodes("//td[position()=7]");
            foreach (var item in result)
            {
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] utfBytes = utf8.GetBytes(item.InnerText);
                byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
                string msg = iso.GetString(isoBytes);

                location.Add(msg);
            }

            // Ödev : Ýstediðiniz herhangi bir siteyi parse edip, Xpath kullanarak istediðiniz html'i almanýzý saðlar.Sizde bu örnek üzerinden istediðiniz bir sitenin bir kýsmýný parse edebilirsiniz.

            return View("Index");
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

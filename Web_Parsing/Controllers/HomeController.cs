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
            return View();
        }
        public IActionResult MoggleSearch(string search)
        {
            List<string> location = new List<string>();
            List<string> urls = new List<string>();
            var web = new WebClient();
            web.Encoding = Encoding.UTF8;
            var html = web.DownloadString("https://deprem.afad.gov.tr/last-earthquakes.html");

            var doc =new  HtmlDocument();
            doc.LoadHtml(html);

            var result =   doc.DocumentNode.SelectNodes("//td[position()=7]");
            foreach (var item in result)
            {
              
               

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

using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
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
            List<string> urls = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load("https://deprem.afad.gov.tr/last-earthquakes.html");
            var result =   doc.DocumentNode.SelectNodes("//tr//td");
            foreach (var item in result)
            {
                
            }

            // �dev : �stedi�iniz herhangi bir siteyi parse edip, Xpath kullanarak istedi�iniz html'i alman�z� sa�lar.Sizde bu �rnek �zerinden istedi�iniz bir sitenin bir k�sm�n� parse edebilirsiniz.

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

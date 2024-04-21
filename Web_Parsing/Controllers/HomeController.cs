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
            var doc = web.Load("https://www.google.com.tr/search?q=" + search);
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a[@href]")
           .ToArray();
            foreach (HtmlNode item in nodes)
            {
                Console.WriteLine(item.InnerHtml);
            }
            List<string> outputList = new List<string>();

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[@class='rc']"))
            {
                outputList.Add(link.InnerText);
            }



            return View();
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

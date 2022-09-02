using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProjectSaba.Data;
using WebProjectSaba.Models;


namespace WebProjectSaba.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        ////GET
        //public IActionResult Login()
        //{
        //    return View();
        //}
        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult LoginPost(User obj)
        //{
        //    var user = 
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
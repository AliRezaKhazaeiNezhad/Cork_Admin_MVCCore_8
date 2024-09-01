using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TGNH.Panel.Models;

namespace TGNH.Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> Logger)
        {
            _logger = Logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return ViewComponent("Error404");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

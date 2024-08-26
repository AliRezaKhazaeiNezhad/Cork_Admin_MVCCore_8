using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TGNH.Panel.Models;

namespace TGNH.Panel.Controllers
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
            var model = new DashbordViewModel
            {
                TotalUsers = 100,
                TotalComments = 200,
                TotalPost = 300,
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

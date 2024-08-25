using Microsoft.AspNetCore.Mvc;
using TGNH.Panel.Models;

namespace TGNH.Panel.Controllers
{
    public class AdminController : Controller
    {
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
    }
}

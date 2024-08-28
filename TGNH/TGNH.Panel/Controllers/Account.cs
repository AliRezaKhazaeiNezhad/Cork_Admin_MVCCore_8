using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Controllers
{
    public class Account : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

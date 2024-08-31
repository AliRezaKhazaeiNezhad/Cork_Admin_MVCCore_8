using Microsoft.AspNetCore.Mvc;
namespace TGNH.Panel.Areas.Loder.ViewComponents
{
    public class LoderViewComponent: ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View("Loder");
        }
    }
}
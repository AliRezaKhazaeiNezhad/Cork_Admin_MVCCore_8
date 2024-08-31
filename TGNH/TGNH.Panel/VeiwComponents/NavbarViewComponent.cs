using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Navbar.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Navbar"));
        }
    }

}

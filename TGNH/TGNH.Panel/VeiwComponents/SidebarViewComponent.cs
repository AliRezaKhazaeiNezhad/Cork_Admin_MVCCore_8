using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Sidebar.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Sidebar"));
        }
    }

}

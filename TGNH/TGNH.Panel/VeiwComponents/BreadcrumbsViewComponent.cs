using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Breadcrumbs.ViewComponents
{
    public class BreadcrumbsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Breadcrumbs"));
        }
    }
}

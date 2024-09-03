using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Error404.ViewComponents
{
    public class Error404ViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Error404"));
        }
    }
}
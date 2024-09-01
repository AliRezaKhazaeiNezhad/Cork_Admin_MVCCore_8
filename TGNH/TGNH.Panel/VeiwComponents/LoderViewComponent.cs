using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Loder.ViewComponents
{
    public class LoderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Loder"));
        }
    }
}

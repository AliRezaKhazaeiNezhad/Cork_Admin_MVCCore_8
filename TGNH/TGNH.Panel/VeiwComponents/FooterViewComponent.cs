using Microsoft.AspNetCore.Mvc;

namespace TGNH.Panel.Areas.Footer.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Footer"));
        }
    }

}



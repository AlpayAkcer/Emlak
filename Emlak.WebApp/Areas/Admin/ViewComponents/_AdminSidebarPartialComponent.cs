using Microsoft.AspNetCore.Mvc;

namespace Emlak.WebApp.Areas.Admin.ViewComponents
{
    public class _AdminSidebarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
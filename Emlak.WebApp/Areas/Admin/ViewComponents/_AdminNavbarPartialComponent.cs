using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.WebApp.Areas.Admin.ViewComponents
{
    public class _AdminNavbarPartialComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.userName = HttpContext.Session.GetString("FullName");

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MktAcademy.Areas.Admin.Controllers
{
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

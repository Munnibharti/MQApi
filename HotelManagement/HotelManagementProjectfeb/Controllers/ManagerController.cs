using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

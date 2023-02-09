using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

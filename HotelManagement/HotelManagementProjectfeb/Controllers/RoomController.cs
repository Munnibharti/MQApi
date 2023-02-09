using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    public class RoomController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}

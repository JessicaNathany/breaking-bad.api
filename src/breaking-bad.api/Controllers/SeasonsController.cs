using Microsoft.AspNetCore.Mvc;

namespace breaking_bad.api.Controllers
{
    public class SeasonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace breaking_bad.api.Controllers
{
    public class EpisodesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace RockstarsHealthCheckVisualization.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

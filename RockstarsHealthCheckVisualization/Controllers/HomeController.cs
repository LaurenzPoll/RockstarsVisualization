using ASPNET_MVC_ChartsDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core;
using RockstarsHealthCheckVisualization.Core.Charts;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChartDataCreator creator;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            creator = new();
        }

        public IActionResult Index()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(creator.Alles());

            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
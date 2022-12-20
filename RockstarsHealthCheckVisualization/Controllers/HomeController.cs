using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core.Charts;
using RockstarsHealthCheckVisualization.DAL;
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
            creator = new(new Repository());
        }

        public IActionResult Index()
        {
            ViewBag.DataPointsBarChart = JsonConvert.SerializeObject(creator.DataForBarGraph());
            List<List<DataPoint>> listDatapoints = creator.GetDataForTrend();
            
            
            
            
            ViewBag.DataPoints = JsonConvert.SerializeObject(listDatapoints.First());
            ViewBag.test = JsonConvert.SerializeObject(creator.GetDataForTrend());

            ViewBag.Amount = listDatapoints.Count;

            //ViewBag.AllDataPieChart = creator.GetDataForTrend();



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
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Models;

namespace RockstarsHealthCheckVisualization.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Chart()
        {
            List<GraphData> dataPoints = new List<GraphData>{
                new GraphData(10, 22),
                new GraphData(20, 36),
                new GraphData(30, 42),
                new GraphData(40, 51),
                new GraphData(50, 46),
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return Json(dataPoints);
        }
    }
}

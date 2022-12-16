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
        private readonly DataBase database;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            creator = new();
            database = new();
        }

        public IActionResult Index()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(creator.DataForBarGraph());

            MailingViewModel model = new MailingViewModel();
            List<EmailDTO> emailDTOs = database.GetEmails();
            foreach (EmailDTO emailDTO in emailDTOs)
            {
                model.IngredientsList.Add(new IngredientModel(ingredientDTO));
            }

            return View(model);

            List<EmailDTO> emails = database.GetEmails();

            return View(emails);
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
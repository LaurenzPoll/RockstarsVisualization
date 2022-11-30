using ASPNET_MVC_ChartsDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            Random random = new Random();


            for (int i = 1; i < 15 + 1; i++)
            {

                dataPoints1.Add(new DataPoint("Question " + i + "", random.Next(0, 50)));
            }

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        //public IActionResult MailUrl()
        //{
        //    MailingViewModel mail = new MailingViewModel();
        //    mail.FillQuestionnaireList();

        //    return View(mail);
        //}

        //[HttpPost]
        //public IActionResult MailUrl(MailingViewModel mail)
        //{

        //    mail.link = URL.GenerateQuestionnaireURL(mail.linkID);
        //    mail.SendMail();


        //    return Ok("De ingetypte mail: " + mail.toEmail + "\nDe gekozen questionnaire: " + mail.linkID);
        //}


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
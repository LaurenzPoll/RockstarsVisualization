using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core.Charts;
using RockstarsHealthCheckVisualization.Models;

namespace RockstarsHealthCheckVisualization.Controllers
{
    public class IndividualController : Controller
    {
        private readonly ChartDataCreator creator;

        public IndividualController()
        {
            creator = new();
        }

        public IActionResult Index()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(creator.DataForBarGraphPerUser());



            return View();
        }

        public IActionResult MailUrl()
        {
            MailingViewModel mail = new MailingViewModel();
            mail.FillSelectQuestionnaireList();

            return View(mail);
        }

        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail)
        {

            mail.link = URL.GenerateQuestionnaireURL(mail.linkID);
            mail.SendMail();

            MailingViewModel newMail = new MailingViewModel();
            newMail.FillSelectQuestionnaireList();

            return View(newMail);
        }
    }
}

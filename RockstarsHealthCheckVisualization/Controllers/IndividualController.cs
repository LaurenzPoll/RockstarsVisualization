using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core;
using RockstarsHealthCheckVisualization.Core.Charts;
using RockstarsHealthCheckVisualization.DAL;
using RockstarsHealthCheckVisualization.Models;


namespace RockstarsHealthCheckVisualization.Controllers
{
    public class IndividualController : Controller
    {
        private readonly ChartDataCreator creator;
        private readonly EmailCollection emailCollection;

        public IndividualController()
        {
            emailCollection = new(new Repository());

            creator = new(new Repository());
        }

        public IActionResult Index()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(creator.DataForBarGraphPerUser());
            List<EmailDTO> emails = emailCollection.GetEmails();
            MailingViewModel model = new MailingViewModel(emails);

            return View(model);
        }

        public IActionResult MailUrl()
        {
            List<EmailDTO> emails = emailCollection.GetEmails();

            EmailCollection mail = new(new Repository());
            mail.FillSelectQuestionnaireList();
            MailingViewModel model = new MailingViewModel(emails);

            return View(model);
        }

        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail)
        {
            mail.link = URL.GenerateQuestionnaireURL(mail.linkID);
            /*mail.SendMultipleEmails();*/

            return RedirectToAction("MailUrl");
        }
    }
}

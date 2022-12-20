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
            emailCollection = new EmailCollection(new Repository());

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

            MailingViewModel mail = new MailingViewModel(emails);
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

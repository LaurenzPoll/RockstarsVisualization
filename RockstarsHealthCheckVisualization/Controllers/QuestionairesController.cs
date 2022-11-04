using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheckVisualization.Models;

namespace RockstarsHealthCheckVisualization.Controllers
{
    public class QuestionairesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MailUrl()
        {
            MailingViewModel mail = new MailingViewModel();
            mail.FillQuestionnaireList();

            return View(mail);
        }

        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail)
        {

            mail.link = URL.GenerateQuestionnaireURL(mail.linkID);
            mail.SendMail();


            return Ok("De ingetypte mail: " + mail.toEmail + "\nDe gekozen questionnaire: " + mail.linkID);
        }
    }
}

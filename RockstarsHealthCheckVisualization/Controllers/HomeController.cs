using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheckVisualization.Core;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    /*[Authorize]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DTOAnswers dTOAnswers = new DTOAnswers();
            List<Answer> answers = dTOAnswers.GetAllAnswers();
            Answer answer = new Answer(answers[0].answerID, answers[0].questionID, answers[0].question, answers[0].filledOutQuestionnaireID, answers[0].answerRange, answers[0].answerComment);
            return View(answer);
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
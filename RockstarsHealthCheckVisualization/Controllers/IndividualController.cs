using Mailjet.Client.Resources;
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
        private readonly UserCollection userCollection;

        public IndividualController()
        {
            emailCollection = new(new Repository());

            creator = new(new Repository());
            userCollection = new(new Repository());
        }

        public IActionResult Index()
        {
            //ViewBag.DataPoints = JsonConvert.SerializeObject(creator.DataForBarGraphPerUser());
            UserCollectionViewModel viewModel = new UserCollectionViewModel();
            viewModel.UserList.AddRange(userCollection.UserList
            .Select(user => new UserViewModel
            {
                UserID = user.UserId,
                Email = user.Email,
                Name = user.Name
            }));

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UserGraph(UserViewModel user)
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(creator.DataForBarGraphPerUser(new Core.User
            {
                UserId = user.UserID,
                Name = user.Name,
                Email = user.Email,
            }));

            return View();
        }

        public IActionResult MailUrl()
        {
            List<EmailDTO> emails = emailCollection.GetEmails();

            EmailCollection mail = new(new Repository());
            mail.FillSelectQuestionnaireList();
            MailingViewModel model = new MailingViewModel(emails, mail.questionnairesList);

            return View(model);
        }

        [HttpPost]
        public IActionResult MailUrl(MailingViewModel mail, string[] selectedEmails)
        {
            for(int i = 0; i < selectedEmails.Length; i++)
            {
                mail.AddEmailToSelectedEmails(selectedEmails[i]);
            }

            emailCollection.link = URL.GenerateQuestionnaireURL(mail.linkID);
            emailCollection.SendMultipleEmails(mail.SelectedEmails);

            return RedirectToAction("MailUrl");
        }
    }
}

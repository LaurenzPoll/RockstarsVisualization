using ASPNET_MVC_ChartsDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DTOAnswers _dTOAnswers;
        private readonly Calculation _calculation;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dTOAnswers = new DTOAnswers();
            _calculation = new Calculation();
        }

        public IActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<int> answerRanges = new List<int>();
            List<int> questionIds = new List<int>();

            List<Answer> answers = _dTOAnswers.GetAllAnswers();
            Answer answer = new Answer(answers[0].answerID, answers[0].questionID, answers[0].question, answers[0].filledOutQuestionnaireID, answers[0].answerRange, answers[0].answerComment);

            Dictionary<int, List<int>> answerDictionary = new();
            foreach (Answer anser in answers)
            {
                if (anser.answerRange <= 0)
                {
                    continue;
                }

                if (!answerDictionary.ContainsKey(anser.questionID))
                {
                    answerDictionary.Add(anser.questionID, new List<int>());
                }
                answerDictionary[anser.questionID].Add(anser.answerRange);
            }

            foreach (var ans in answers)
            {
                if (ans.answerRange > 0)
                {
                    answerRanges.Add(ans.answerRange);
                    questionIds.Add(ans.questionID);
                }
            }

            Dictionary<int, double> averages = _calculation.GetAverageAnswerRange(answerDictionary);
            foreach (var avg in averages)
            {
                if (answers.Find(x => x.questionID == avg.Key).question.Contains("[Trend]"))
                {
                    continue;
                }

                dataPoints.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, avg.Value));
                /*for (int i = 0; i < answers.Count; i++)
                {
                    bool check = answers[i].question.Contains("[Trend]");
                    if (!check)
                    {
                        dataPoints.Add(new DataPoint(answers[i].question, avg));
                    }
                }*/
            }
            //😀😀😀
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            /*foreach (var ans in answers)
            {
                if (ans.answerRange > 0)
                {
                    range.Add(ans.answerRange);
                    ViewBag.rangeList = range;
                }
                else
                {
                    trend.Add(ans.answerRange);
                    ViewBag.trendList = trend;
                }
            }*/

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
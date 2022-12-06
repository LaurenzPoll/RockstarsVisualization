using ASPNET_MVC_ChartsDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockstarsHealthCheckVisualization.Core;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    [Authorize]
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

                dataPoints.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value)));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);


            return View();
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
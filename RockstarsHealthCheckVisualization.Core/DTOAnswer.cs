using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class DTOAnswer
    {
        public int AnswerID { get; set; }
        public int FilledOutQuestionnaireID { get; set; }
        public int FilledOutQuestionnaireName { get; set; }
        public int ProjectID { get; set; }
        public int ProjectName { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string QuestionCategory { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int AnswerRange { get; set; }
        public string? AnswerComment { get; set; }
        public DateTime Date { get; set; }




    }
}

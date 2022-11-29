using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class DTOAnswer
    {
        public int AnswerID { get; set; } // *dbo.Answers
        public int FilledOutQuestionnaireID { get; set; } // *dbo.Answers
        public int QuestionnaireName { get; set; } // dbo.Questionnaires OUTER JOIN > dbo.Questionnaires_Questions > dbo.Questions > dbo.Answers
        public int ProjectID { get; set; } // dbo.Projects OUTER JOIN > dbo.User_Project > dbo.Users > dbo.FilledOutQuestionnaires > dbo.Answers
        public int ProjectName { get; set; } // dbo.Projects OUTER JOIN > dbo.User_Project > dbo.Users > dbo.FilledOutQuestionnaires > dbo.Answers
        public int QuestionID { get; set; } // *dbo.Answers
        public string Question { get; set; } // *dbo.Questions INNER JOIN > dbo.Answers
        public string QuestionCategory { get; set; } // dbo.Categories OUTER JOIN > dbo.Questions > dbo.Answers
        public int UserID { get; set; } // *dbo.Users OUTER JOIN > dbo.FilledOutQuestionnaires > dbo.Answers
        public string UserFirstName { get; set; } // dbo.Users OUTER JOIN > dbo.FilledOutQuestionnaires > dbo.Answers
        public string UserLastName { get; set; } // dbo.Users OUTER JOIN > dbo.FilledOutQuestionnaires > dbo.Answers
        public int AnswerRange { get; set; } // dbo.Answers
        public string? AnswerComment { get; set; } // dbo.Answers
        public DateTime Date { get; set; } // *dbo.FilledOutQuestionnaires OUTER JOIN > dbo.Answers




    }
}

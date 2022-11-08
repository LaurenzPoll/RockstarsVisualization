using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class FilledOutQuestionnaire
    {
        private int filledOutQuestionnaireId;  // key
        private int questionnaireId;
        internal int projectId { get; }
        internal string employeeEmail { get; }
        internal DateTime dateTime { get; }
        private List<Answer> answers;


        public FilledOutQuestionnaire(int filledOutQuestionnaireId, int questionnaireId, int projectId, string employeeEmail, DateTime dateTime)
        {
            this.filledOutQuestionnaireId = filledOutQuestionnaireId;
            this.questionnaireId = questionnaireId;
            this.projectId = projectId;
            this.employeeEmail = employeeEmail;
            this.dateTime = dateTime;

        }

        public void AddAnswer(Answer answer)
        {
            this.answers.Add(answer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core.GarbageBin
{
    internal class FilledOutQuestionnaire
    {
        private int Id;  // key
        private int questionnaireId;
        internal int projectId { get; }
        internal string employeeEmail { get; }
        internal DateTime dateTime { get; }
        private List<Answer> answers;


        public FilledOutQuestionnaire(int Id, int questionnaireId, int projectId, string employeeEmail, DateTime dateTime)
        {
            this.Id = Id;
            this.questionnaireId = questionnaireId;
            this.projectId = projectId;
            this.employeeEmail = employeeEmail;
            this.dateTime = dateTime;

        }

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }
    }
}

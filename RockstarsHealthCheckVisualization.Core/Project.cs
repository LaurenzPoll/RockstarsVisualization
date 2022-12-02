using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class Project
    {
        internal int projectId { get; }  // key
        private string projectName;
        private string company;
        private Questionnaire questionnaire;
        internal List<Employee> employees { get; }
        internal List<FilledOutQuestionnaire> filledOutQuestionnaires { get; }

        public Project(int projectId, string projectName, Questionnaire questionnaire, string company)
        {
            this.projectId = projectId;
            this.projectName = projectName;
            this.company = company;
            List<Employee> employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void AddQuestionaire(Questionnaire questionnaire)
        {
            this.questionnaire = questionnaire;
        }

        public void AddFilledOutQuestionaire(FilledOutQuestionnaire filledOutQuestionnaire)
        {
            this.filledOutQuestionnaires.Add(filledOutQuestionnaire);
        }

        
    }
}

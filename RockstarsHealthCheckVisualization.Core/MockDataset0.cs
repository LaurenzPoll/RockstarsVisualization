using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class MockDataSet0
    {
        internal string nameMockDataSet { get; }
        internal string descriptionMockDataSet;
        private List<Manager> managers;

        private Questionnaire questionnaire;
        // add option for several kinds of questionnaires, for now the mock data only works with one kind of questionnaire per mock data set

        private DataCollection dataCollection;

        private int nrOfManagers = 3;
        private int nrOfProjects = 6;
        private int nrOfEmployees = 12;
        private int nrOfFilledOutQuestionnaires = 36;
        private int nrOfQuestionnaires = 1;


        internal MockDataSet0()
        {
            this.nameMockDataSet = "Mock data set nr. 1";
            this.descriptionMockDataSet = GetDescriptionMockDataSet1();

            this.managers = GetManagers();  // managers only contain email addresses after invocing this method, not yet projects, employees and filledOutQuestionnaires

            DataCollection dataCollection = new DataCollection(managers);
        }

        internal string GetDescriptionMockDataSet1()
        {
            string decription =
            "Suitable for basic testing and presentation.\n" +
            "Managers: 3\n" +
            "Projects: 6\n" +
            "Employees: 12\n" +
            "Filled out questionnaires: 36\n" +
            "Questionnaires: 1" +
            "Notes: for now only for one kind of questionnaire and only for Rockstars employees (see method MakeEmailAddresses in class MockDataGenerator)";

            return decription;
        }

        internal List<Manager> GetManagers()
        {
            List<Manager> managers = new List<Manager>();
            MockDataGenerator generator = new MockDataGenerator();
            for (int i = 0; i < this.nrOfManagers; i++)
            {
                // make manager, for which argument email address is needed, which is obtained through method MakeEmailAdresses in MockDataGenerator class
                Manager manager = new Manager(generator.MakeEmailAddresses(this.nrOfManagers)[i]);
            }
            return managers;
        }

        internal List<Project> GetProjects()
        {
            return new List<Project>();
        }

        internal Questionnaire GetQuestionnaire1()
        {
            int questionnaireId = 000001;
            string questionnaireName = "Standard Questionnaire";

            // Quality
            Question q1 = new Question(000000, "How do you value your delivered work?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);
            Question q2 = new Question(000001, "How easy is it to release?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);
            Question q3 = new Question(000002, "How healthy is the code base?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);

            // Progress
            Question q4 = new Question(000003, "Is the current working process suitable?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);
            Question q5 = new Question(000004, "Is the speed sufficient?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);
            Question q6 = new Question(000005, "Is the mission of the project clear?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);

            // Team
            Question q7 = new Question(000006, "Is the teamwork going well?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);
            Question q8 = new Question(000007, "How is the quality of support?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);
            Question q9 = new Question(000008, "How good is the working atmosphere?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);

            // Individual
            Question q10 = new Question(000009, "Are you having fun?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);
            Question q11 = new Question(000010, "Do you experience autonomy in your work?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);
            Question q12 = new Question(000011, "Are you learning enough along the way?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);

            List<Question> questions = new List<Question>()
            {
                q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12
            };

            Questionnaire questionnaire = new Questionnaire(questionnaireId, questionnaireName, questions);

            return questionnaire;
        }


    }
}
